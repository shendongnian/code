        protected void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }
            storage = value;
            OnPropertyChanged(propertyName);
        }
        protected void Set(ref double storage, double value, [CallerMemberName]string propertyName = null)
        {
            if (NegligibleChange(storage, value))
            {
                return;
            }
            storage = value;
            OnPropertyChanged(propertyName);
        }
        private bool NegligibleChange(double  x, double y)
        {
            return Math.Abs(x - y) <= 1e-10;
        }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
