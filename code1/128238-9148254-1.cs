    public class Order : INotifyPropertyChanged
    {
        decimal itemPrice;
        int quantity;
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public decimal ItemPrice
        {
            get { return itemPrice; }
            set
            {
                if (itemPrice != value)
                {
                    itemPrice = value;
                    OnPropertyChanged("TotalPrice");
                    OnPropertyChanged("ItemPrice");
                }
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged("TotalPrice");
                    OnPropertyChanged("Quantity");
                }
            }
        }
        public decimal TotalPrice
        {
            get { return ItemPrice*Quantity; }
        }
    }
