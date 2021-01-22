    using (StreamReader outFile = new StreamReader(outputFile.OpenRead()),
                        expFile = new StreamReader(expectedFile.OpenRead()))
       {
          while (!(outFile.EndOfStream || expFile.EndOfStream))
           {
             if (outFile.ReadLine() != expFile.ReadLine())
             return false;
           }
        }
