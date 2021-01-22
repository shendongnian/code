        var sr = new StreamReader(File.OpenRead(@"C:\Temp\in.txt"));
        var sw = new StreamWriter(File.OpenWrite(@"C:\Temp\out.txt"));
        var lines = new HashSet<int>();
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            int hc = line.GetHashCode();
            if(lines.Contains(hc))
                continue;
            lines.Add(hc);
            sw.WriteLine(line);
        }
        sw.Flush();
        sw.Close();
        sr.Close();
