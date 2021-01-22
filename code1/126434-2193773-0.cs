     public class SomeViewModel
        {
            public string SomeFormValue
            {
                get;
                set;
            }
            public string SomeOtherFormValue
            {
                get;
                set;
            }
            public AddressViewModelComponent Address
            {
                get;
                set;
            }
        }
        public class AddressViewModelComponent
        {
            public string AddressLineOne
            {
                get;
                set;
            }
            public string AddressLineTwo
            {
                get;
                set;
            }
            // Etc
        }
