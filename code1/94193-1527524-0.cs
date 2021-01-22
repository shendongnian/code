    List<SimpleAddress> CreateList(AddressList address)
    {
        List<SimpleAddress> values = new List<SimpleAddress>();
        Type type = address.GetType();
        for (int i=1;i<=99;++i)
        {
             string address = type.GetProperty("Address" + i.ToString()).GetValue(address,null).ToString();
             string addressDesc = type.GetProperty("Address" + i.ToString() + "Desc").GetValue(address,null).ToString();
             string addressName = type.GetProperty("Address" + i.ToString() + "Name").GetValue(address,null).ToString();
 
             if (!string.IsNullOrEmpty(addressDesc) || !string.IsNullOrEmpty(addressName) || !string.IsNullOrEmpty(address)  )
                  value.Add(new SimpleAddress(address,addressDesc,addressName));
        }
        return values;
     }
    
