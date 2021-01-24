    private static void WezKomponent(string ass, string sax)
    {
        ManagementObjectSearcher wez = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + ass);
        foreach (ManagementObject pie in wez.Get())
        {
            Console.WriteLine(Convert.ToString(pie[sax]));
            StreamWriter SW = new StreamWriter(@"HDD.txt");
            SW.WriteLine(Convert.ToString(pie[sax]));
            SW.Close();
        }
    }
