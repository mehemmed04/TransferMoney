using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TransferMoney.Commands;
using TransferMoney.Models;

namespace TransferMoney.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        private string cardNumber;

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        public List<User> Users { get; set; }


        private User user;

        public User User
        {
            get { return user; }
            set { user = value;OnPropertyChanged(); }
        }

        public RelayCommand LoadDataCommand { get; set; }
        public RelayCommand InsertCardCommand { get; set; }
        public MainViewModel()
        {
            IsEnabled = false;
            User = new User();
            Users = new List<User>()
            {
                new User
                {
                     CardNumber="4098584465729489",
                     FullName="Mehemmed Bayramov",
                     Balance=4321.43
                },
                new User
                {
                     CardNumber="1122334455667788",
                     Balance=2233.12,
                     FullName="Remzi Hesenov"
                },
                new User
                {
                    CardNumber="1111222233334444",
                    FullName="Nurlan Shirinov",
                    Balance=4467.36
                }
            };

            InsertCardCommand = new RelayCommand((o) =>
            {
                IsEnabled = !IsEnabled;
            });

        LoadDataCommand = new RelayCommand((o) =>
            {
                User = Users.FirstOrDefault((u) => { return u.CardNumber == CardNumber; });
                if (User == null) MessageBox.Show("User not found");
            });


        }
    }
}
