    public class B : A
    {
        private object _someProperty;
        public object SomeProperty
        {
            get => _someProperty;
            set
            {
                _someProperty = value;
                RaisePropertyChanged();
            }
        }
    }
