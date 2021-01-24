    //using Newtonsoft.Json;
    var jsonData = JsonConvert.DeserializeAnonymousType(
        data,
        new 
        {
          events = new[]
          {
            new
            { 
              Id = new { info = "", stats = "", away = "", odds = "" }
            }
          }
      );            
            
    foreach(var item in jsonData.events)
    {
        var id=item.info.id; // getting id present in info
    }
