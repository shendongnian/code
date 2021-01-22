    List<object> list = new List<Object>();
    
    Cache["ObjectList"] = list;                 // add
    list = ( List<object>) Cache["ObjectList"]; // retrieve
    Cache.Remove("ObjectList");                 // remove
