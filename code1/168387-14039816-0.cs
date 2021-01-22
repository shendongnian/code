    dynamic json = new JDynamic("{a:'abc'}");
    //json.a is a string "abc"
    
    dynamic json = new JDynamic("{a:3.1416}");
    //json.a is 3.1416m
    
    dynamic json = new JDynamic("{a:1}");
    //json.a is
    dynamic json = new JDynamic("[1,2,3]");
    /json.Length/json.Count is 3
    //And you can use json[0]/ json[2] to get the elements
    
    dynamic json = new JDynamic("{a:[1,2,3]}");
    //json.a.Length /json.a.Count is 3.
    //And you can use  json.a[0]/ json.a[2] to get the elements
    
    dynamic json = new JDynamic("[{b:1},{c:1}]");
    //json.Length/json.Count is 2.
    //And you can use the  json[0].b/json[1].c to get the num.
