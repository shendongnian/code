    ipBridge[] responseModel = JsonConvert.DeserializeObject<ipBridge[]>(responseString); 
    var locatedBridgeModel = responseModel.Select(x => new LocatedBridge() { BridgeId = x.Id, IpAddress = x.InternalIpAddress }).ToList();
    
    Console.WriteLine($"{responseModel[0].InternalIpAddress}"); 
    //or
    Console.WriteLine($"{locatedBridgeModel[0].IpAddress}"); 
    //or
    Console.WriteLine($"{locatedBridgeModel.First().IpAddress}"); 
