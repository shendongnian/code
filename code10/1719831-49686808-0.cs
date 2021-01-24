    var returnValue = (IList)GetItems.Invoke(utility, null);
    foreach (var item in returnValue)
    {
        var type = item.GetType();
        var property = type.GetProperty("FirstName");
        var firstName = property.GetValue(item);
    }
