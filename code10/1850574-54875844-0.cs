    var client = new ODataClient("http://services.odata.org/V4/TripPinServiceRW/");
    
    var x = ODataDynamic.Expression;
    IEnumerable<dynamic> values = await client
        .For(x.Photos)
        .FindEntriesAsync();
    
        foreach (var photo in values)
        {
          Console.WriteLine(photo.Name);
        }
    
    return "success";
