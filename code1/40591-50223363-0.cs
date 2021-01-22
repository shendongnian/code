    getAnyProperty("[servername]", @"CN=[cn name]", "description");
       public List<string> getAnyProperty(string originatingServer, string distinguishedName, string propertyToSearchFor)
        {
            string path = "LDAP://" + originatingServer + @"/" + distinguishedName;
            DirectoryEntry objRootDSE = new DirectoryEntry(path, [Username], [Password]);
    // DirectoryEntry objRootDSE = new DirectoryEntry();
            List<string> returnValue = new List<string>();
            System.DirectoryServices.PropertyCollection properties = objRootDSE.Properties;
            foreach (string propertyName in properties.PropertyNames)
            {
                PropertyValueCollection propertyValues = properties[propertyName];
                if (propertyName == propertyToSearchFor)
                {
                    foreach (string propertyValue in propertyValues)
                    {
                        returnValue.Add(propertyValue);
                    }
                }
            }
            return returnValue;
        }
