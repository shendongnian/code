    var newUser = new User();
    PropertyInfo propertyInfo;
    foreach (var row in propList)
    {
        var longestValueUser = list.OrderByDescending(x => x.GetType().GetProperty(row).GetValue(x, null).ToString().Length).First();
        var longestValue = longestValueUser.GetType().GetProperty(row).GetValue(longestValueUser, null);
        propertyInfo = newUser.GetType().GetProperty(row);
        propertyInfo.SetValue(newUser, Convert.ChangeType(longestValue, propertyInfo.PropertyType), null);
    }
    
