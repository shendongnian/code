    string json = "{p1:\'Hello\'";                              
    
    string tmpjs = ",p2:\'world\'}";   
    json = json + tmpjs;
    using(YourService service = new YourService()) 
    {
        service.Credentials = new NetworkCredential("user", "pwd", "domain");
        serivce.YourServiceMethod(json, param2);
    }
