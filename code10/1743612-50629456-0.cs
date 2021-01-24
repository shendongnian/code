    Regex regex = new Regex("onclick=\"\\$ll.CATG.toggleCb\\((.*),\\s?(.*),\\s?(.*),\\s?(.*)\\)");
    string x = "<button class=\"longlist - cb longlist - cb - yes\" id=\"cb46032\" onclick=\"$ll.CATG.toggleCb(this, '46032', '46032', '2002_MAX_ALLOW_DATE')\"></button>";
    Match match = regex.Match(x);
    if (match.Success)
    {
        Console.WriteLine("match.Value returns: " + match.Value);
        foreach (Group y in match.Groups)
        {
            Console.WriteLine("the current capture group: " + y.Value);
        }
    }
    else
    {
        Console.Write("No match");
    }
    Console.ReadKey();
