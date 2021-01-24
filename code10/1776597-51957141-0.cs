    public class MyObject : INotifyPropertyChanged
    {
        double amount;
        bool hasAmountChanged = false;
        public event PropertyChangedEventHandler PropertyChanged;
        public MyObject(double amount)
        {
            this.amount = amount;
        }
        public double Amount
        {
            get => amount;
            set
            {
                if (amount != value)
                {
                    amount = value;
                    OnPropertyChanged(nameof(Amount));
                    HasAmountChanged = true;
                }
            }
        }
        public bool HasAmountChanged
        {
            get => hasAmountChanged;
            set
            {
                if (hasAmountChanged != value)
                {
                    hasAmountChanged = value;
                    OnPropertyChanged(nameof(HasAmountChanged));
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
