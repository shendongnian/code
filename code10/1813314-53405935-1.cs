    [WebMethod]
    public static Dictionary<int, string> ReadFile()
    {
        Dictionary<int, string> datalist = new Dictionary<int, string>();
        var lines = File.ReadAllLines(@"C:\\temp\\Sample.txt");
        int i = 1;
        foreach (var line in lines)
        {
            datalist.Add(i, line);
            i++;
        }
        return datalist;
    }
