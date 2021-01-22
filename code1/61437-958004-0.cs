    // This class implements a simple customer type 
    // that implements the IPropertyChange interface.
    public class DemoCustomer : INotifyPropertyChanged
    {
        // These fields hold the values for the public properties.
        private Guid idValue = Guid.NewGuid();
        private string customerName = String.Empty;
        private string companyNameValue = String.Empty;
        private string phoneNumberValue = String.Empty;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    
        // The constructor is private to enforce the factory pattern.
        private DemoCustomer()
        {
            customerName = "no data";
            companyNameValue = "no data";
            phoneNumberValue = "no data";
        }
    
        // This is the public factory method.
        public static DemoCustomer CreateNewCustomer()
        {
            return new DemoCustomer();
        }
    
        // This property represents an ID, suitable
        // for use as a primary key in a database.
        public Guid ID
        {
            get
            {
                return this.idValue;
            }
        }
    
        public string CompanyName
        {
            get {return this.companyNameValue;}
    
            set
            {
                if (value != this.companyNameValue)
                {
                    this.companyNameValue = value;
                    NotifyPropertyChanged("CompanyName");
                }
            }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumberValue; }
    
            set 
            {
                if (value != this.phoneNumberValue)
                {
                    this.phoneNumberValue = value;
                    NotifyPropertyChanged("PhoneNumber");
                }
            }
        }
    }
