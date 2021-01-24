    using System.Text.RegularExpressions;
    
    string stringOutput = "a:toyota:c";
    readonly List<string> carMake = new List<string>
        {
            "Toyota",
            "Honda",
            "Audi",
            "Tesla"
        };
                
    string pattern = @".+?:(.+?):.+?";
            
    foreach (Match m in Regex.Matches(stringOutput, pattern))
    {
        if (carMake.Any(s=>s.Equals(m.Groups[1].Value, StringComparison.InvariantCultureIgnoreCase)))
        {
            stringOutput = stringOutput.Replace(m.Groups[1].Value, carMake.First(s=>s.Equals(m.Groups[1].Value, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
    
    Console.WriteLine(stringOutput);
