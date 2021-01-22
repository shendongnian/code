    [WebMethod] 
    public string getData(string name) 
    { 
       var result = myObject.Where( z => z.name == name )
                            .ToList()
                            .Select( k => 
                                new 
                                { 
                                    a = k.A, 
                                    b = k.B, 
                                    c = getValueByKey(k.C)
                                })
                            .ToList(); 
 
        return new JavaScriptSerializer().Serialize(result); 
    } 
