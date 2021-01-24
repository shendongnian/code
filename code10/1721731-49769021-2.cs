    var longestNameUser = list.OrderByDescending(x => x.GetType().GetProperty("Name").GetValue(x, null).ToString().Length).First();
    var longestName = longestNameUser.GetType().GetProperty("Name").GetValue(longestNameUser, null);
    var longestCarUser = list.OrderByDescending(x => x.GetType().GetProperty("Car").GetValue(x, null).ToString().Length).First();
    var longestCar = longestCarUser.GetType().GetProperty("Car").GetValue(longestCarUser, null);
    User newUser = new User();
    PropertyInfo propertyInfo;
    
    propertyInfo = newUser.GetType().GetProperty("Name");
    propertyInfo.SetValue(newUser, Convert.ChangeType(longestName, propertyInfo.PropertyType), null);
    
    propertyInfo = newUser.GetType().GetProperty("Car");
    propertyInfo.SetValue(newUser, Convert.ChangeType(longestCar, propertyInfo.PropertyType), null);
    
