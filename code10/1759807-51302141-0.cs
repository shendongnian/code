    public class Invoice
    {
        public string Name { get; set; }
        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; NotifyPropertyChanged(nameof(TotalPrice)); }
        }
        private double _tax;
        public double Tax
        {
            get { return _tax; }
            set { _tax = value; NotifyPropertyChanged(nameof(TotalPrice)); }
        }
        private double _discount;
        public double Discount
        {
            get { return _discount; }
            set { _discount = value; NotifyPropertyChanged(nameof(TotalPrice)); }
        }
        private double _amount;
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; NotifyPropertyChanged(nameof(TotalPrice)); }
        }
        public double TotalPrice
        {
            get
            {
                return (_price * _amount + _tax) * (1 - _discount);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
