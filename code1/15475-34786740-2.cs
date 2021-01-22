    using System.ComponentModel;
    public class TestMyClassWithINotifyPropertyChangedInterface : INotifyPropertyChanged
    {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void NotifyPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
            private int id;
    
            public int Id
            {
                get { return id; }
                set { id = value;
                    NotifyPropertyChanged("Id");
                }
            }
    }
