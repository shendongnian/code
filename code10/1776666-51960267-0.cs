    DateTime date; 
     if(DateTime.TryParseExact(values[0], "yyyy-MM-dd", 
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out date)
    {
       //succeeded, date contains the value
    }
    else
    {
      //error
    }
