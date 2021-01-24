    string[] lines = { "From 1 March 1960 To 1 March 2235", 
                       "For a period starting 1/3/1960 and ending 1/3/2235", 
                       "Starting 1.3.1960 and ending 1.3.2235", 
                       "Just some string with no dates in it" };
    foreach (string line in lines) {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(System.Environment.NewLine + line);
        Console.ResetColor();
        if (Regex.IsMatch(line, @"(\d{1,2}\s+\w+\s+\d{4})"))
        {
            Regex regexObj = new Regex(@"(\d{1,2}\s+\w+\s+\d{4})");
            Match matchResults = regexObj.Match(line);
            while (matchResults.Success)
            {
                DateTime dte = DateTime.ParseExact(matchResults.Value, "d MMMM yyyy", CultureInfo.GetCultureInfo("en-GB"));
                Console.WriteLine(dte);
                matchResults = matchResults.NextMatch();
            }
        }
        else if (Regex.IsMatch(line, @"(\d{1,2}[./]\d{1,2}[./]\d{4})"))
        {
            Regex regexObj = new Regex(@"(\d{1,2}[./]\d{1,2}[./]\d{4})");
            Match matchResults = regexObj.Match(line);
            while (matchResults.Success)
            {
                DateTime dte = DateTime.ParseExact(matchResults.Value.Replace(".","/"), "d/M/yyyy", CultureInfo.GetCultureInfo("en-GB"));
                Console.WriteLine(dte);
                matchResults = matchResults.NextMatch();
            }
        }
        else { Console.WriteLine("No valid date found."); }
    }
