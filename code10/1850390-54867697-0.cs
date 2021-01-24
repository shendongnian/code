    using System.Globalization;
    ...
    DateTime searchDateTime = new DateTime(2019, 2, 25, 16, 15, 45);
    // Escape delimiters with apostrophes '..' if you want to preserve them
    string test = searchDateTime.ToString(
      "dd'-'MMM'-'yyyy' 'h':'mm':'ss' 'tt", 
       CultureInfo.InvariantCulture);
    DateTime date = DateTime.ParseExact(
       test, 
      "dd'-'MMM'-'yyyy' 'h':'mm':'ss' 'tt", 
       CultureInfo.InvariantCulture); 
    string result = date.ToString(
      "MM'/'dd'/'yyyy' 'h':'mm':'ss' 'tt", 
       CultureInfo.InvariantCulture);
    Console.WriteLine(test);
    Console.Write(result);
