    static void Main(string[] args)
    {
        double totalFenner = 0.0;
        double totalAbom = 0.0;
        double total = 0.0;
        double meanFenner = 0.0;
        double meanAbom = 0.0;
        double meanTotal = 0.0;
        var samples = File.ReadLines("examdata.csv")
                     .Select(l => Samples.ReadCsv(l));
        int count = 0;
        foreach (var sample in samples)
        {
            totalFenner += sample.Fenner;
            totalAbom += sample.Abom;
            count++
        }
        total = totalFenner + totalAbom;
        meanTotal = total / count;
        meanFenner = totalFenner / count;
        meanAbom = totalAbom / count;
        Console.WriteLine(meanFenner);
        Console.WriteLine(meanAbom);
        Console.WriteLine(meanTotal);
         Pause();
    }
