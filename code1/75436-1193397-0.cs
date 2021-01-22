    var list3 = new List<MyClass>();
    
    foreach(var item in list1)
    {
       var totalFromOther = list2.Where(x => x.id == item.id).Sum(y => y.HourBy);
       var newItem = new MyClass() { id = item.Id, HourBy = item.HourBy - totalFromOther };
       if(newItem.HourBy > 0)
         list3.Add(newItem);
    }
