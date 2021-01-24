    static void Main(string[] args)
    {
        string filePath = @"C:\Users\QuantMoment\Documents\Python_ML\FXDemo\EURUSD.csv";
        int adet = 0;
        Console.WriteLine($"Reading Start {DateTime.Now}");
        var Okuma = Stopwatch.StartNew();
        List<TickData> TickListem = new List<TickData>();
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
