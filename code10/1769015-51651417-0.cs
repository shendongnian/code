    namespace TestBind
    {
        public class ExampleModel : INotifyPropertyChanged
        {
    
            private string counter;
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
            public ExampleModel()
            {
                this.Counter = "0 words found";
            }
    
            public string Counter
            {
                get { return this.counter; }
                set
                {
                    this.counter = value;
                    this.OnPropertyChanged();
                }
            }
    
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
