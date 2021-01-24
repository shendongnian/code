    using (var sr = new StreamReader(inFile))
       using (var sw = new StreamWriter(OutFile))
          while (!sr.EndOfStream)
          {
              var line1 = sr.ReadLine();
              if (line1.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0)
                 continue;
        
              sw.WriteLine(line1);
              sw.WriteLine(sr.ReadLine());
          }
