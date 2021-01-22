    public class Dude : INotifyPropertyChanged
        {
            private string name;
            private int age;
    
            public int Age
            {
                get { return this.Age; }
                set
                {
                    this.age = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs("Age"));
                    }
                }
            }
            public string Name
            {
                get
                {
                    return this.name;
                }
    
                set
                {
                    this.name = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            
        }
