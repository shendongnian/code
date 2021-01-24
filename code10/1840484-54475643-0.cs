	/// <summary>
    /// Class for a Licence
    /// </summary>
    class Licence
    {
        public string sKey { get; set; }
        public string sExpiry { get; set; }
        public string sName { get; set; }
    }
    static void Main(string[] args)
    {
        // Loading the data with a WebClient
        WebClient WB = new WebClient();
		// Downloads the string
		string whitelist = WB.DownloadString("https://pastebin.com/raw/ai8q5GEA");
		// List with all licences
		List<Licence> licences = new List<Licence>();
		// Foreach Row
		foreach (string sRow in whitelist.Split('\n'))
        {
            // Splits the Row
            string[] sData = sRow.Split('|');
            // Adds the licence data
            licences.Add(new Licence
            {
                sKey = sData[0],
                sExpiry = sData[1],
                sName = sData[2]
            });
        }
        // User input
        string fin = String.Format("2222-2222-2222-2222");
        // Gets the licence class for the specific key
        Licence lic = licences.Find(o => o.sKey == fin);
        // If there a licence found
        if (lic != default(Licence))
        {
            // Uses the licence class for data output
            var date = DateTime.ParseExact(lic.sExpiry, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var result1 = (date - DateTime.Now.Date).Days;
            if (result1 >= 0)
            {
                Console.WriteLine(string.Concat(new string[]
                {
                    "License key is valid.",
                    Environment.NewLine,
                    Environment.NewLine,
                    "Hi ", lic.sName, "! Key expires on the ", lic.sExpiry,
                    Environment.NewLine,
                    "Restart DeluxeUnban."
                }));
            }
        }
        Console.WriteLine("FINISHED");
        Console.ReadKey();
    }
