    static void Main()
    {
        object obj = new Customer { Address = new Address { ZipCode = "abcdef" } };
        object address = GetValue(obj, "Address");
        object zip = GetValue(address, "ZipCode");
        Console.WriteLine(zip);
    }
    static object GetValue(object component, string propertyName)
    {
        return TypeDescriptor.GetProperties(component)[propertyName].GetValue(component);
    }
