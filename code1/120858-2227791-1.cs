    private static void ListContacts(ExchangeService svc) {
        foreach (var v in svc.FindItems(WellKnownFolderName.Contacts,
                                        new ItemView(20))) {
            Contact contact = v as Contact;
            ContactGroup contactGroup = v as ContactGroup;
            //v.Load(); // Turns out you don't need to load for basic props.
            if (contact != null) {
                Console.WriteLine("Contact: {0} <{1}>",
                    contact.DisplayName,
                    contact.EmailAddresses[EmailAddressKey.EmailAddress1]);
            } else if (contactGroup != null) {
                Console.WriteLine("Contact Group: {0}", contactGroup.DisplayName);
                switch (svc.RequestedServerVersion) {
                    case ExchangeVersion.Exchange2007_SP1:
                        ExpandGroupResults groupResults
                            = svc.ExpandGroup((contactGroup.Id));
                        foreach (var member in groupResults) {
                            Console.WriteLine("+ {0} <{1}>",
                                member.Name, member.Address);
                        }
                        break;
                    case ExchangeVersion.Exchange2010:
                        foreach (GroupMember member in contactGroup.Members) {
                            Console.WriteLine("+ {0} <{1}>",
                            member.AddressInformation.Name,
                            member.AddressInformation.Address);
                        }
                        break;
                    default:
                        Console.WriteLine(
                            "** Unknown Server Version: {0}",
                            svc.RequestedServerVersion);
                        break;
                }
            } else {
                Console.WriteLine("Unknown contact type: {0} - {1}",
                    contact.GetType(), v.Subject);
            }
        }
    }
