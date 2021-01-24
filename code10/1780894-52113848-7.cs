    private static void WezKomponent(string ass, string sax)
    {
        using (var wez = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + ass))
            File.WriteAllLines(@"HDD.txt", wez.Get().Select(pie => ConvertToString(pie[sax])));
    }
