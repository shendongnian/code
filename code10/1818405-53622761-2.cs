    static void Main(string[] args)
    {
        Console.WriteLine($"Reading Start {DateTime.Now}");
        string filePath = @"C:\Users\QuantMoment\Documents\Python_ML\FXDemo\EURUSD.csv";
        int adet = 0;
        List<TickData> TickListem = new List<TickData>();
        var Okuma = Stopwatch.StartNew();
        var lines = File.ReadLines(filePath); //this just opens the file, doesn't really start to read from it yet 
        foreach(string line in lines)
        {
            //the biggest cost here BY FAR will be parsing the fields from the line, rather than adding to the list.
            TickListem.Add(new TickData(line));
            adet++;
        }
        Okuma.Stop();
        Console.WriteLine($"Number of rows               : {adet} ");
        Console.WriteLine($"CSV Reading Total Time(sec)  : {Okuma.Elapsed}");
    }
