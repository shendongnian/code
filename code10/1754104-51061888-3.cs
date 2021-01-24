    // Data or View Models
    public class AddressViewModel : BaseViewModel
    {
        public string Address {get;set;}
        public AddressViewModel()
        {
            this.Address ="Address";
        }
        
    }
    public class UserViewModel : BaseViewModel
    {
        public string Name {get;set;}
        public UserViewModel()
        {
            this.Name ="Name";
        }
    }
    public class BaseViewModel
    {
        
    }
