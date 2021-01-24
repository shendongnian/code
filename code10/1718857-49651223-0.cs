    var formats = new string[] 
    {
        "yyyy:MM:dd HH:mm:ss",
        "yyyy/MM/dd HH:mm:ss",
        "yyyy-MM-dd HH:mm:ss"
    };
    DateTime dt;
    if(
       DateTime.TryParseExact(
           str, 
           formats, 
           System.Globalization.CultureInfo.InvariantCulture, 
           DateTimeStyle.AssumeLocal, 
           out dt)
     ) // parsed successfully...
