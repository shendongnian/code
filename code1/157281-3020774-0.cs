    using System.ComponentModel;
    namespace MyNS
    {
        pubic class Person : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private int age = 0;
            public int Age
            {
                get { return age; }
                set
                {
                    age = value;
                    OnPropertyChanged("Age");
                }
            }
            protected void OnPropertyChanged(string PropertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(PropertyName));
                }
            }
            public void GetOlder
            {
                age++;
            }
        }
    }
