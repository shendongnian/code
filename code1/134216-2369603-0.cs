    var customService = new CustomService();  
    customService.srv = new Service() { ID = 409 };  
    var srvProperty = customService.GetType().GetProperty("srv");  
    var srvValue = srvProperty.GetValue(customService, null);  
    var id = srvValue.GetType().GetProperty("ID").GetValue(srvValue, null);  
    Console.WriteLine(id);
