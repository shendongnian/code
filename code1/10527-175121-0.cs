    using System.ComponentModel;
    namespace INotifyPropertyChangeSample
    {
        public class Person : INotifyPropertyChanged
        {
            private string firstName;
            public string FirstName
            {
                get { return firstName; }
                set
                {
                    if (firstName != value)
                    {
                        firstName = value;
                        OnPropertyChanged("FirstName");
                        OnPropertyChanged("FullName");
                    }
                }
            }
            private string lastName;
            public string LastName
            {
                get { return lastName; }
                set
                {
                    if (lastName != value)
                    {
                        lastName = value;
                        OnPropertyChanged("LastName");
                        OnPropertyChanged("FullName");
                    }
                }
            }
            public string FullName
            {
                get { return firstName + " " + lastName; }
            } 
            
            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            #endregion
        }
    }
