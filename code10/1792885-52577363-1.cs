    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace WindowsFormsApp1
    {
        public class PersonViewPresenter : ViewPresenterBase
        {
            private string _lastName;
            private string _firstName;
    
            public string FirstName
            {
                get => _firstName; set
                {
                    if (_firstName != value)
                    {
                        _firstName = value;
                        NotifyPropertyChanged();
                    }
                }
            }
    
            public string LastName
            {
                get => _lastName; set
                {
                    if (_lastName != value)
                    {
                        _lastName = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }
    
        public abstract class ViewPresenterBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
