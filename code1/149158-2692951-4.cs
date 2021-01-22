    string propPath = "ShippingInfo.Address.Street";
    object propValue = propPath.Split('.').Aggregate(
        (object)this,
        (value, name) => value.GetType().GetProperty(name).GetValue(value, null));
    Console.WriteLine("The value of " + propPath + " is: " + propValue);
