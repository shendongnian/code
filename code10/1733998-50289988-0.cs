        EmailAddressCollection roomLists = service.GetRoomLists();
        foreach (EmailAddress email in roomLists)
        {
            EmailAddress roomList = email.Address;
            PropertySet props = new PropertySet(BasePropertySet.FirstClassProperties);
            NameResolutionCollection nrCol = service.ResolveName(email.Address, ResolveNameSearchLocation.DirectoryOnly, true, props);
            foreach (NameResolution nr in nrCol)
            {
                Console.WriteLine(nr.Contact.DisplayName);
            }
        }
