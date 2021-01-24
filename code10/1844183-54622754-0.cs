    public void ReplaceAllVowels()
    {
        List<string> Instruments = new List<string>();
        Instruments.Add("cello");
        Instruments.Add("guitar");
        Instruments.Add("violin");
        Instruments.Add("double bass");
        var pattern = new Regex("[aeiouy]");
        var lst = Instruments.Select(i => pattern.Replace(i, "")).ToList();
        foreach (var item in lst)
        {
            Console.WriteLine(item);
        }
    }
