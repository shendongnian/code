       class Program
    {
        private RightNowSyncPortClient _Service;
        public Program()
        {
            _Service = new RightNowSyncPortClient();
            _Service.ClientCredentials.UserName.UserName = "Rightnow UID";
            _Service.ClientCredentials.UserName.Password = "Right now password";
        }
        private Contact Contactinfo()
        {
            Contact newContact = new Contact();
            PersonName personName = new PersonName();
            personName.First = "conatctname";
            personName.Last = "conatctlastname";
            newContact.Name = personName;
            Email[] emailArray = new Email[1];
            emailArray[0] = new Email();
            emailArray[0].action = ActionEnum.add;
            emailArray[0].actionSpecified = true;
            emailArray[0].Address = "mail@mail.com";
            NamedID addressType = new NamedID();
            ID addressTypeID = new ID();
            addressTypeID.id = 1;
            addressType.ID = addressTypeID;
            addressType.ID.idSpecified = true;
            emailArray[0].AddressType = addressType;
            emailArray[0].Invalid = false;
            emailArray[0].InvalidSpecified = true;
            newContact.Emails = emailArray;
            return newContact;
        }
        public long CreateContact()
        {
            Contact newContact = Contactinfo();
            //Set the application ID in the client info header
            ClientInfoHeader clientInfoHeader = new ClientInfoHeader();
            clientInfoHeader.AppID = ".NET Getting Started";
            //Set the create processing options, allow external events and rules to execute
            CreateProcessingOptions createProcessingOptions = new CreateProcessingOptions();
            createProcessingOptions.SuppressExternalEvents = false;
            createProcessingOptions.SuppressRules = false;
            RNObject[] createObjects = new RNObject[] { newContact };
            //Invoke the create operation on the RightNow server
            RNObject[] createResults = _Service.Create(clientInfoHeader, createObjects, createProcessingOptions);
            //We only created a single contact, this will be at index 0 of the results
            newContact = createResults[0] as Contact;
            return newContact.ID.id;
        }
        
        static void Main(string[] args)
        {
            Program RBSP = new Program();
            try
            {
                long newContactID = RBSP.CreateContact();
                System.Console.WriteLine("New Contact Created with ID: " + newContactID);
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Code);
                Console.WriteLine(ex.Message);
            }
            System.Console.Read();
          
        }
    }
