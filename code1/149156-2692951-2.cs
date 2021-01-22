    string propPath = "ShippingInfo.Address.Street";
    object propValue = propPath.Split('.').Aggregate(
        (object)this,
        (v, n) => v.GetType().GetProperty(n).GetValue(v, null));
    Console.WriteLine("The value of " + propPath + " is: " + propValue);
