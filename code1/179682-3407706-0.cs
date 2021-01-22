    var datestring = "20000101";
    var date1 = DateTime.ParseExact(datestring, "yyyyMMdd", null);
    // ... or ...
    DateTime dateResult;
    if (!DateTime.TryParseExact(
        datestring, 
        "yyyyMMdd", 
        null, 
        DateTimeStyles.AssumeLocal, 
        out dateResult))
        dateResult = DateTime.MinValue; //handle failed conversion here
