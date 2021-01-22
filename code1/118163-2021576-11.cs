    public ParentViewModel : ViewModel
    {
         public AddressViewModel AddressVM
         {
              ...
         }
    
         public ParentViewModel()
         {
              AddressVM = new AddressViewModel();
         }
    }
