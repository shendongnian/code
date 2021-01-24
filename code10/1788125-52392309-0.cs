    var inputDateString = "12/31/2017 12:00:00 AM";
    string datePortion = string.Empty;
    DateTime dt;
    if (inputDateString.Length>10)
    {
        // take first 10 characters of inputDateString
        datePortion = inputDateString.Substring(0, Math.Min(inputDateString.Length, 10));
    }
    else if (inputDateString.Length==10)
    {
        // inputDateString is already 10 characters
        datePortion = inputDateString;
    }
    else
    {
        // inputDateString is less than 10 characters, no date found, do nothing.
    }
    if(!DateTime.TryParse(datePortion, out dt))
    {
       // handle error that occurred, 
    }
    else
    {
        // parse was successful, carry on.
    }
