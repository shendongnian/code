    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TestNotifyChanged tnc;
        public ViewModel(TestNotifyChanged t)
        {
            tnc = t;
            tnc.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Test) || string.IsNullOrEmpty(e.PropertyName))
                {
                    Test = tnc.Test; // update ViewModel.Test from TestNotifyChanged.Test
                }
            };
        }
        private string test;
        public string Test
        {
            get
            {
                return test; // always return own value
            }
            set
            {
                if (test != value)
                {
                    test = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Test)));
                    tnc.Test = Test; // update TestNotifyChanged.Test from ViewModel.Test
                }
            }
        }
    }
