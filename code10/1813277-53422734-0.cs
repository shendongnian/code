    public class Country
    {
        public string CountryName { get; set; }
        public List<string> CommonMisspellings { get; set; }
        public Country()
        {
            CommonMisspellings = new List<string>();
        }
    }
    static void Main()
    {
        var counties = new List<Country>();
        Dictionary<string, string> dict = new Dictionary<string, string>();
        Random rnd = new Random();
        List<string> allCountryNames = new List<string>();
        List<string> allMissNames = new List<string>();
        for (int state = 0; state < 100; ++state)
        {
            string countryName = state.ToString() + rnd.NextDouble();
            allCountryNames.Add(countryName);
            var country = new Country { CountryName = countryName };
            counties.Add(country);
            for (int miss = 0; miss < 100; ++miss)
            {
                string missname = countryName + miss;
                allMissNames.Add(missname);
                country.CommonMisspellings.Add(missname);
                dict.Add(missname, countryName);
            }
        }
        List<string> testNames = new List<string>();
        for (int i = 0; i < 100000; ++i)
        {
            if (rnd.Next(20) == 1)
            {
                testNames.Add(allMissNames[rnd.Next(allMissNames.Count)]);
            }
            else
            {
                testNames.Add(allCountryNames[rnd.Next(allCountryNames.Count)]);
            }
        }
        System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
        st.Start();
        List<string> repairs = new List<string>();
        foreach (var test in testNames)
        {
            if (counties.Any(c => c.CommonMisspellings.Contains(test)))
            {
                repairs.Add(counties.First(c => c.CommonMisspellings.Contains(test)).CountryName);
            }
        }
        st.Stop();
        Console.WriteLine("List approach: " + st.ElapsedMilliseconds.ToString() + "ms");
        st = new System.Diagnostics.Stopwatch();
        st.Start();
        List<string> repairsDict = new List<string>();
        foreach (var test in testNames)
        {
            if (dict.TryGetValue(test, out var val))
            {
                repairsDict.Add(val);
            }
        }
        st.Stop();
        Console.WriteLine("Dict approach: " + st.ElapsedMilliseconds.ToString() + "ms");
        Console.WriteLine("Repaired count: " + repairs.Count
            + ", check " + (repairs.SequenceEqual(repairsDict) ? "OK" : "ERROR"));
        Console.ReadLine();
    }
