    char sep = '\t';
    var result = text
            .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(new char[] sep, StringSplitOptions.RemoveEmptyEntries))
            .GroupBy(items => new {
              key1 = items[1],
              key2 = items[2],
              key3 = items[3], })
           .SelectMany(chunk => chunk
              .Select((items, index) => index == 0
                 ? string.Join(sep.ToString(), items)
                 : string.Join(sep.ToString(), 
                     items[0], 
                     items[1], 
                   $"{items[2]}/{index}", 
                     string.Join(sep.ToString(), items.Skip(3)))));
    
           Console.Write(result);
