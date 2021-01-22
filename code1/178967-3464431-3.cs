    private static XDocument SerializeAsAttributes(Person person)
    {
        return new XDocument(
            new XElement("Person",
                         new XAttribute("Name", person.Name),
                         new XAttribute("Telephone", person.Telephone),
                         SerializeAddressAsAttributes(person.HomeAddress, "HomeAddress"),
                         SerializeAddressAsAttributes(person.WorkAddress, "WorkAddress"))
            );
    }
    
    private static XElement SerializeAddressAsAttributes(Address address, string elementName)
    {
        return new XElement(elementName,
                            new XAttribute("Line1", address.Line1),
                            new XAttribute("Line2", address.Line2),
                            new XAttribute("City", address.City),
                            new XAttribute("State", address.State),
                            new XAttribute("PostalCode", address.PostalCode)
            );
    }
