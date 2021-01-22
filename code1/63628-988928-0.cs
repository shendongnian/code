    public class BusinessModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set 
            { 
                _quantity = value;
                this.OnPropertyChanged("Quantity");            
            }
        }
        void OnPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
     }
