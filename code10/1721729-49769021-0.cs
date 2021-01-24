    var longestNameUser = list.OrderByDescending(x => x.GetType().GetProperty("Name").GetValue(x, null).ToString().Length).First();
    var longestName = longestNameUser.GetType().GetProperty("Name").GetValue(longestNameUser, null);
    var longestCarUser = list.OrderByDescending(x => x.GetType().GetProperty("Car").GetValue(x, null).ToString().Length).First();
    var longestCar = longestCarUser.GetType().GetProperty("Car").GetValue(longestCarUser, null);
    var longestUser = new User() { Name = longestName.ToString(), Car = longestCar.ToString() };
