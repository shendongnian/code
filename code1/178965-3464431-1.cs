    private static void Main()
    {
        var person = new Person
                         {
                             Name = "John Saunders",
                             Telephone = "something",
                             HomeAddress = new Address
                                               {
                                                   Line1 = "Line 1",
                                                   Line2 = "Line 2",
                                                   City = "SomeCity",
                                                   State = "SS",
                                                   PostalCode = "99999-9999",
                                               },
                             WorkAddress = new Address
                                               {
                                                   Line1 = "Line 1a",
                                                   Line2 = "Line 2a",
                                                   City = "SomeCitay",
                                                   State = "Sa",
                                                   PostalCode = "99999-999a",
                                               },
                         };
        XDocument personWithElements = SerializeAsElements(person);
        personWithElements.Save("PersonWithElements.xml");
        XDocument personWithAttributes = SerializeAsAttributes(person);
        personWithAttributes.Save("PersonWithAttributes.xml");
    }
