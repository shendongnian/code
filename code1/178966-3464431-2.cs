    private static XDocument SerializeAsElements(Person person)
    {
        return new XDocument(
            new XElement("Person",
                         new XElement("Name", person.Name),
                         new XElement("Telephone", person.Telephone),
                         SerializeAddressAsElements(person.HomeAddress, "HomeAddress"),
                         SerializeAddressAsElements(person.WorkAddress, "WorkAddress"))
            );
    }
    
    private static XElement SerializeAddressAsElements(Address address, string elementName)
    {
        return new XElement(elementName,
                            new XElement("Line1", address.Line1),
                            new XElement("Line2", address.Line2),
                            new XElement("City", address.City),
                            new XElement("State", address.State),
                            new XElement("PostalCode", address.PostalCode)
            );
    }
