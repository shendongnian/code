    public static void WriteFormattedTextToNewFile(List<string> groupedStrings)
    {
        string file = @"C:\Users\e011691\Desktop\New folder\formatted.txt";
        using (var sw = new StreamWriter(file, true))
        {
            sw.Write($"{DateTime.Now:yyyy MM dd  hh:mm:ss}\t\t");
    
            for(int i = 0; i<ReadFile.GroupStrings.Count;i++)
            {
               for(int j = 0; j<50 && i<ReadFile.GroupStrings.Count; j++)
               {
                  sw.Write("{ReadFile.GroupedStrings[i]}\t");
               }
               sw.WriteLine();
            }
        }
    }
