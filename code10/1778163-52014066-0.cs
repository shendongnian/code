    List<Consumption> newList = new List<Consumption>();
    var name = new Consumption { Name = "name" };
    foreach (var item in calories)
    {
        var cal = new Consumption{ Name = "name", Calories = (double)item.Value });
        newList.Add(cal);
    }
