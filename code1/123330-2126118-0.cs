    public static string GetMostPopular(ArrayList vals)
    {
        IDictionary<string, int> dict = new Dictionary<string, int>();
        foreach (string x in vals)
        {
            if (!dict.ContainsKey(x))
            {
                dict[x] = 1;
            }
            else
            {
                dict[x]++;
            }
        }
        string ret = "";
        int mx = 0;
        foreach (string key in dict.Keys)
        {
            if (dict[key] > mx)
            {
                mx = dict[key];
                ret = key;
            }
        }
        return ret;
    }
    static void Main()
    {
        ArrayList arrName = new ArrayList();
        arrName.Add("BOB");
        arrName.Add("JOHN");
        arrName.Add("TOM");
        arrName.Add("TOM");
        arrName.Add("TOM");
        string ans = GetMostPopular(arrName);
        Console.WriteLine(ans);
    }
