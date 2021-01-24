    public class AddressViewModel
    {
        public string StreeNo { get; set; }
        public string Town { get; set; }
    }
    public Class PersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressViewModel[] Addresses { get; set; }
    }
    // Automapper profile
    CreateMap<Address, AddressViewModel();
    CreateMap<Person, PersonViewModel>();
    // Usage
    var personViewModelList = MapDynamicList<PersonViewModel>(persons);
