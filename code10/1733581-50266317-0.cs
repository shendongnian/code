            PropertySet exProp = new PropertySet(BasePropertySet.FirstClassProperties);
            NameResolutionCollection ncCol = service.ResolveName("user@domain.com", ResolveNameSearchLocation.DirectoryOnly, true, exProp);
            if (ncCol.Count == 1)
            {
                Console.WriteLine(ncCol[0].Contact.DirectoryId);
            }
