    namespace MyProject.Views
    {
        public class AddressLookup
        {
            public string Postcode { get; set; }
            public string FirstLine { get; set; }
        }
        public class RegistrationViewModel
        {
            [DisplayName("Address Lookup")]
            [UIHint("AddressLookup")]
            public AddressLookup addressLookup { get; set; }
        }
    }
