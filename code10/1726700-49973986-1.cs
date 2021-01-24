    XDocument xdoc = XDocument.Load(@"your xml path");
    var teams = xdoc.Descendants("Team");
    foreach (XElement team in teams)
    {
        var firstElement = team.Elements();//Get all elements, here is only one element
        var participants = firstElement.Elements();
        int teamCount = participants.Count();
        var teamName = team.FirstAttribute.Value;
        Console.Out.WriteLine("{0} contains {1} member(s)...", teamName, teamCount); 
    }
    Console.ReadLine();
