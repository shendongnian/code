    List<string> lst = new List<string>();
    lst.Add("Apple"); 
    lst.Add("Guva");
    lst.Add("Graps"); 
    lst.Add("PineApple");
    lst.Add("Orange"); 
    lst.Add("Mango");
    
    var customers = lst.OrderBy(c => Guid.NewGuid()).FirstOrDefault();
