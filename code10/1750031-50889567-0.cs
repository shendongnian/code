    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        ...
    }
    public class CustomerViewModel : ViewModelBase
    {
        private Customer _customer;
        public string Name
        {
            get => _customer.Name;
            set
            {
                if(_customer.Name != value)
                {
                     _customer.Name = value;
                     OnPropertyChanged();
                }
            }
        }
    }
