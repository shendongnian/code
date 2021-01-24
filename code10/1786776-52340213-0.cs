    Regex reg = new Regex("{(\\w+)}");     
    var text = "Hello this is a {Testvar}... and we have more {Tagvar} in this string {Endvar}.";
    string[] tagResult = reg.Matches(text)
    	.Cast<Match>()
    	.Select(match => match.Groups[1].Value).ToArray();
    foreach (var item in tagResult)
    {
    	Console.WriteLine(item);
    }
