    var s = "Request closed by Jack Arm on 08/16/2018,Assignee #1 James Arye assigned by Scotty Shep on 08/16/2018,Request submitted by Mac Weaver on 08/16/2018,Request created by Mac Weaver on 08/16/2018";
    var pattern = @"((?:[a-zA-Z'-]+[^a-zA-Z'-]+){0,2})assigned by((?:[^a-zA-Z'-]+[a-zA-Z'-]+){0,2})";
    var matches = Regex.Matches(s, pattern);
    foreach (Match match in matches)
	{
       	Console.WriteLine(match.Groups[1].Value.Trim());
       	Console.WriteLine(match.Groups[2].Value.Trim());
	}
