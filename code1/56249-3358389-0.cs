    // use reflection to retrieve the values of the following anonymous type
    var obj = new { ClientId = 7, ClientName = "ACME Inc.", Jobs = 5 }; 
    System.Type type = obj.GetType(); 
    int clientid = (int)type.GetProperty("ClientId").GetValue(obj, null);
    string clientname = (string)type.GetProperty("ClientName").GetValue(obj, null);
    // use the retrieved values for whatever you want...
