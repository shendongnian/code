     public class DataBindings
        {
            public ContactData Contact { get; set; }
            public OrganizationData Organization { get; set; }
            public OtherData Other { get; set; }
    
            public DataBindings()
            {
                Organization = new OrganizationData();
                Organization.Address = "123 Test Street";
    
                Contact = new ContactData();
                Contact.Address = "456 Test Street";
            }
        }
