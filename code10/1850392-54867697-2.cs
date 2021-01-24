    using System.Globalization;
    ...
    DateTime searchDateTime = new DateTime(2019, 2, 25, 16, 15, 45);
    // Escape delimiters with apostrophes '..' if you want to preserve them
    string test = searchDateTime.ToString(
      "dd'-'MMM'-'yyyy' 'h':'mm':'ss' 'tt", 
       CultureInfo.InvariantCulture);
    // Parse string with known format into DateTime 
    DateTime date = DateTime.ParseExact(
       test, 
      "dd'-'MMM'-'yyyy' 'h':'mm':'ss' 'tt", 
       CultureInfo.InvariantCulture); 
    // Presenting DateTime as a String with the desired format 
    string result = date.ToString(
      "MM'/'dd'/'yyyy' 'h':'mm':'ss' 'tt", 
       CultureInfo.InvariantCulture);
    Console.WriteLine($"Initial: {test}");
    Console.Write($"Final:   {result}");
