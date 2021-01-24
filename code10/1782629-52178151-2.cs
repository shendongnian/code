    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using GalaSoft.MvvmLight.Command;
    using WpfApp2.Data;
    
    namespace WpfApp2.ViewModel
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            public MainViewModel()
            {
                PopulateUserTestData();
                UpdateCommand = new RelayCommand<User>(UpdateUser);
            }
    
            private ObservableCollection<User> _users;
    
            public ObservableCollection<User> Users
            {
                get => _users;
                set
                {
                    if (_users != value)
                    {
                        _users = value;
                        NotifyPropertyChanged();
                    }
                }
            }
    
            private UserRole _userRole;
            public UserRole SelectedUserRole
            {
                get => _userRole;
                set
                {
                    if (_userRole != value)
                    {
                        _userRole = value;
                        NotifyPropertyChanged();
                    }
                }
            }
    
            public RelayCommand<User> UpdateCommand { get; }
    
            public IEnumerable<UserRole> UserRoles => Enum.GetValues(typeof(UserRole)).Cast<UserRole>();
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            private void UpdateUser(User user)
            {
                Users.Single(u => u.UserId == user.UserId).UserRole = SelectedUserRole;
               
                // Do updates on your context (or in-memory).
                PrintUsersOnDebug();
            }
    
            #region Test data and diagnostics support
    
            private void PrintUsersOnDebug()
            {
                foreach (User user in Users)
                {
                    Debug.WriteLine("Username: " + user.UserName + " Role: " + user.UserRole);
                }
            }
    
            private void PopulateUserTestData()
            {
                Users = new ObservableCollection<User>
                {
                    new User
                    {
                        UserId = 1,
                        UserCreatedDate = DateTime.Now,
                        UserEmail = "johndoe1@email.com",
                        UserFirstName = "John",
                        UserLastName = "Doe",
                        UserName = "johnd",
                        UserRole = UserRole.Administrator
                    },
                    new User
                    {
                        UserId = 2,
                        UserCreatedDate = DateTime.Now,
                        UserEmail = "billgordon@email.com",
                        UserFirstName = "Bill",
                        UserLastName = "Gordon",
                        UserName = "billg",
                        UserRole = UserRole.SuperUser
                    }
                };
    
                PrintUsersOnDebug();
            }
    
            #endregion
        }
    }
