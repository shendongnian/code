    private static void Test_StringStreamReader(string filename) {
        var sw = new Stopwatch();
        sw.Start();
        using (var sr = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read))) {
            var r = new StringSteamReader(sr);
            r.Separator = ' ';
            while (!r.EOF) {
                var dbls = new List<double>();
                while (!r.EOF) {
                    dbls.Add(r.ReadDouble());
                }
            }
        }
        sw.Stop();
        Console.WriteLine("elapsed: {0}", sw.Elapsed);
    }
    private static void Test_ReadLine(string filename) {
        var sw = new Stopwatch();
        sw.Start();
        using (var sr = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read))) {
            var dbls = new List<double>();
            while (!sr.EndOfStream) {
                string line = sr.ReadLine();
                string[] bits = line.Split(' ');
                foreach(string bit in bits) {
                    dbls.Add(double.Parse(bit));
                }
            }
        }
        sw.Stop();
        Console.WriteLine("elapsed: {0}", sw.Elapsed);
    }
    private static void Test_ReadAllLines(string filename) {
        var sw = new Stopwatch();
        sw.Start();
        string[] lines = System.IO.File.ReadAllLines(filename);
        var dbls = new List<double>();
        foreach(var line in lines) {
            string[] bits = line.Split(' ');
            foreach (string bit in bits) {
                dbls.Add(double.Parse(bit));
            }
        }        
        sw.Stop();
        Console.WriteLine("Test_ReadAllLines: {0}", sw.Elapsed);
    }
