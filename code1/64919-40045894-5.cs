    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp.example.com/");
    request.Credentials = new NetworkCredential("user", "password");
    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
    string pattern =
        @"^([\w-]+)\s+(\d+)\s+(\w+)\s+(\w+)\s+(\d+)\s+" +
        @"(\w+\s+\d+\s+\d+|\w+\s+\d+\s+\d+:\d+)\s+(.+)$";
    Regex regex = new Regex(pattern);
    IFormatProvider culture = CultureInfo.GetCultureInfo("en-us");
    string[] hourMinFormats =
        new[] { "MMM dd HH:mm", "MMM dd H:mm", "MMM d HH:mm", "MMM d H:mm" };
    string[] yearFormats =
        new[] { "MMM dd yyyy", "MMM d yyyy" };
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        Match match = regex.Match(line);
        string permissions = match.Groups[1].Value;
        int inode = int.Parse(match.Groups[2].Value, culture);
        string owner = match.Groups[3].Value;
        string group = match.Groups[4].Value;
        long size = long.Parse(match.Groups[5].Value, culture);
        DateTime modified;
        string s = Regex.Replace(match.Groups[6].Value, @"\s+", " ");
        if (s.IndexOf(':') >= 0)
        {
            modified = DateTime.ParseExact(s, hourMinFormats, culture, DateTimeStyles.None);
        }
        else
        {
            modified = DateTime.ParseExact(s, yearFormats, culture, DateTimeStyles.None);
        }
        string name = match.Groups[7].Value;
        Console.WriteLine(
            "{0,-16} permissions = {1}  size = {2, 9}  modified = {3}",
            name, permissions, size, modified.ToString("yyyy-MM-dd HH:mm"));
    }
