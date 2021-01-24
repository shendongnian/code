    var item1 = new News1BE() 
    {
        PublishedDate = DateTime.Now
    };
    
    var item2 = new News1BE()
    {
        PublishedDate = item1.PublishedDate.AddSeconds(-30)
    };
    
    sortedList.Add(item1.PublishedDate, item1);
    
    //item2 goes before item1
    sortedList.Add(item2.PublishedDate, item2);
    
    foreach(var x in sortedList)
    {
        Console.WriteLine(x.Key);
    }
