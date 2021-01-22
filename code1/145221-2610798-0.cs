    // Parse date and time with custom specifier.
    string dateString = "Tue Jan 20 20:47:43 2009";
    string format = "ddd MMM dd HH:mm:ss yyyy";
    DateTime result;
    System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
     
    try
    {
       result = DateTime.ParseExact(dateString, format, provider);
       Console.WriteLine("{0} converts to {1}.", dateString, result.ToString());
    }
    catch (FormatException)
    {
       Console.WriteLine("{0} is not in the correct format.", dateString);
    }
 
 
