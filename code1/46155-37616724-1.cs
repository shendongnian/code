    var mergedList=new List<Person>();
    
    foreach(var item in list1)
    {
        mergedList.Add(item);
    }
    foreach(var item in list2)
    {
       if(!mergedList.Contains(item))
       {
         mergedList.Add(item);
       }
    }
