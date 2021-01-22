    List<SimpleAddress> addresses = new List<SimpleAddress>();
    
    string addressPropertyPattern = "Address{0}";
    string namePropertyPattern = "Address{0}Name";
    string descPropertyPattern = "Address{0}Desc";
    for(int i = 1; i <= MAX_ADDRESS_NUMBER; i++)
    {
        System.Reflection.PropertyInfo addressProperty = typeof(AddressList).GetProperty(string.Format(addressPropertyPattern, i));
        System.Reflection.PropertyInfo nameProperty = typeof(AddressList).GetProperty(string.Format(namePropertyPattern, i));
        System.Reflection.PropertyInfo descProperty = typeof(AddressList).GetProperty(string.Format(descPropertyPattern, i));
    
        SimpleAddress address = new SimpleAddress();
    
        address.Address = (string)addressProperty.GetValue(yourAddressListObject, null);
        address.Name = (string)nameProperty.GetValue(yourAddressListObject, null);
        address.Description = (string)descProperty.GetValue(yourAddressListObject, null);
    
        addresses.Add(address);
    }
