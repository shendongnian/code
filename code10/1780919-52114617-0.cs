    public string ParseLine(string Line)
    {
       ...
       if(!DateTime.TryParseExact(input[0], "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out var result))
         {
             //Is not a valid date :C
         }
    
       Console.WriteLine("Valid date: " + result);
    }
