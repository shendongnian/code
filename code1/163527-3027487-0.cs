    using System.Text.RegularExpressions;
    Regex pattern = new Regex(".*\/([a-z\-]+)\.html");
    Match match = pattern.Match("http://sfsdf.com/sdfsdf-sdfsdf/sdf-as.html");
    if (match.Success)
    {
    	Console.WriteLine(match.Value);
    }
    else
    {
    	Console.WriteLine("Not found :(");
    }
