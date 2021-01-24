    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TestNotifyChanged tnc;
        public ViewModel(TestNotifyChanged tnc)
        {
            this.tnc = tnc;
            this.tnc.PropertyChanged += (s, e) => Test = tnc.Test; // here
        }
        private string test;
        public string Test
        {
            get
            {
                return test; // here
            }
            set
            {
                if (test != value)
                {
                    test = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Test"));
                    tnc.Test = Test; // and here
                }
            }
        }
    }
