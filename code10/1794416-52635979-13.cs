    public static void WriteFormattedTextToNewFile(List<string> groupedStrings)
    {
        string file = @"C:\Users\e011691\Desktop\New folder\formatted.txt";
        using (var sw = new StreamWriter(file, true))
        {
            sw.Write($"{DateTime.Now:yyyy MM dd  hh:mm:ss}\t\t");
    
            foreach(var strings in groupedStrings.Chunk(50))
            {
                sw.WriteLine(string.Join("\t", strings.ToArray()));
            } 
        }
    }
