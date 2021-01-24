    public string ParseLine(string Line)
    {
       ...
       if(!DateTime.TryParseExact(input[0], "ddMMyyyy hh:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.None, out var result))
         {
             //Is not a valid date :C
         }
    
       Console.WriteLine("Valid date: " + result);
    }
