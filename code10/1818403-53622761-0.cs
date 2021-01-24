    static void Main(string[] args)
    {
        Console.WriteLine($"Reading Start {DateTime.Now}");
        var Okuma = Stopwatch.StartNew();
        string filePath = @"C:\Users\QuantMoment\Documents\Python_ML\FXDemo\EURUSD.csv";
        int adet = 0;
        List<TickData> TickListem = new List<TickData>();
        var lines = File.ReadLines(filePath); //this just opens the file, doesn't really start to read from it yet
   
        foreach(string line in lines)
        {
            TickListem.Add(new TickData(line));
            adet++;
        }
        Okuma.Stop();
        Console.WriteLine($"Number of rows               : {adet} ");
        Console.WriteLine($"CSV Reading Total Time(sec)  : {Okuma.Elapsed}");
    }
