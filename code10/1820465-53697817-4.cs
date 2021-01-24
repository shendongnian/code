    static void Main(string[] args)
    {
        var samples = File.ReadLines("examdata.csv")
                     .Select(l => Samples.ReadCsv(l))
                     .ToList();
           
        double totalFenner = samples.Select(s => s.Fenner).Sum();
        double totalAbom = samples.Select(s => s.Abom).Sum();
        double total = totalFenner + totalAbom;
        double meanFenner = sampes.Select(s => s.Fenner).Avg();
        double meanAbom = samples.Select(s => s.Abom).Avg();
        double meanTotal = samples.Select(s => s.Fenner + s.Abom).Avg();
        Console.WriteLine(meanFenner);
        Console.WriteLine(meanAbom);
        Console.WriteLine(meanTotal);
         Pause();
    }
