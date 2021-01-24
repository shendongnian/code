    public static void WriteFormattedTextToNewFile(List<string> groupedStrings)
    {
        string file = @"C:\Users\e011691\Desktop\New folder\formatted.txt";
        using (var sw = new StreamWriter(file, true))
        {
            sw.Write($"{DateTime.Now:yyyy MM dd  hh:mm:ss}\t\t");
    
            for(int i = 0; i < groupedStrings.Count;i++)
            {
                sw.Write($"{groupedStrings[i]}\t");
                if (i > 0 && i % 50 == 0) { sw.WriteLine(); }
            }
        }
    }
