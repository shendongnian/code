    public class MainViewModel
    {
        public MainViewModel()
        {
            Customers = new ObservableCollection<CustomerViewModel>();
        }        
    
        //no dependency.
        public ICommand LoadCustomersCommand { get; set; }
    
        public ObservableCollection<CustomerViewModel> Customers { get; private set; }
    }
