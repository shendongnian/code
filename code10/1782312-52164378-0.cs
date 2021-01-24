            Stopwatch sw = Stopwatch.StartNew();
            System.Console.WriteLine("Starting");
            string path = @"C:\big.txt";
            StringBuilder stringBuilder = new StringBuilder();
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                stringBuilder.Append(sr.ReadToEnd());
            }
            sw.Stop();
            System.Console.WriteLine($"Complete Time :{sw.ElapsedMilliseconds}");
            System.Console.ReadKey();
