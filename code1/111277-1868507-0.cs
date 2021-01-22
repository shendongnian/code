    static void ManyParms(
        string a, string b, string c, int d, short e, bool f, string g)
    {
        var hack = new { a, b, c, d, e, f, g };
        foreach (PropertyInfo pi in hack.GetType().GetProperties())
        {
            Console.WriteLine("{0}: {1}", pi.Name, pi.GetValue(hack, null));
        }
    }
