    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TestNotifyChanged tnc;
        public ViewModel(TestNotifyChanged t)
        {
            tnc = t;
            tnc.PropertyChanged += (s, e) => // here
            {
                if (e.PropertyName == nameof(Test) || string.IsNullOrEmpty(e.PropertyName))
                {
                    Test = tnc.Test;
                }
            };
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Test)));
                    tnc.Test = Test; // and here
                }
            }
        }
    }
