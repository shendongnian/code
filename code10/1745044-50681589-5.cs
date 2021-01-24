    List<Demo> list = new List<Demo>();
    list.Add(new Demo("amit", false));
    
    //Note here we are also setting x.flag to true with checking conditions 
    if(list.Any(x => x.Name == "amit"  && !x.flag && (x.flag = true)))
    {
    }
