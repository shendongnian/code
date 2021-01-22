    public class Order : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get { return ItemPrice*Quantity; }
        }
    }
