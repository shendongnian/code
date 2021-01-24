    var lst = new List<dynamic>();
    dynamic obj = new ExpandoObject();
    obj.Name = "John";
    obj.CreateDate = DateTime.Now;
    lst.Add(obj);
    obj = new ExpandoObject(); // re-instantiate the obj if you want to differentiate from the List itself
    obj.Name = "Sara";
    obj.CreateDate = DateTime.Now.AddMonths(-10);
    lst.Add(obj);
    foreach (var item in lst)
    {
        Console.WriteLine($"{item.Name} - {item.CreateDate}");
    }
