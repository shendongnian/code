    public class MyData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private decimal _basePrice;
        public decimal basePrice
        {
           get { return _basePrice; }
           set { _basePrice = value;  UpdatePrice(); }
        }
        private decimal _price;
        public decimal price
        {
           get { return _price; }
        }
        private int _discount;
        public int discount
        {
           get { return _discount; }
           set { _discount = value; UpdatePrice(); }
        }
        
        private void UpdatePrice()
        {
             _price = _basePrice * (100 - _discount) * 0.01M;
            OnPropertyChanged("price");
        } 
    }
