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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Test)));
                }
            };
        }
        public string Test
        {
            get { return tnc.Test; }
            set { tnc.Test = Test; }
        }
    }
