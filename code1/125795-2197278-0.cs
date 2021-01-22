     var t1 = from line in StreamReaderExtension.ReadLinesFromFile(@"alkahf.txt")
                         let parts = line.Split(new string[]{". "},StringSplitOptions.RemoveEmptyEntries)
                         where !string.IsNullOrEmpty(line)                     
                         && int.Parse(parts[0].ToString()).ToString() != ""
                         select new
                         {
                             Index = parts[0],
                             Text = parts[1]
                         };
