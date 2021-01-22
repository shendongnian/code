    string propPath = "ShippingInfo.Address.Street";
    object propValue = this;
    foreach (string propName in propPath.Split('.'))
    {
        PropertyInfo propInfo = propValue.GetType().GetProperty(propName);
        propValue = propInfo.GetValue(propValue, null);
    }
    Console.WriteLine("The value of " + propPath + " is: " + propValue);
