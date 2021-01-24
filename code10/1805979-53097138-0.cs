    using System.Linq;
    ...
  
    // Our initial data
    var data = File
      .ReadLines(path1)
      .Skip(1) // Skip 1st record (header)
      .Where(line => !string.IsNullOrWhiteSpace(line)) // remove empty lines, if any 
      .Select(line => line.Split('|'))                 // split each line by |
      .Select(items => new {
         Raw  = string.Join("|", items),               // Raw data as it is in the file
         Date = items[0].Trim(),
         ID  = items[1].Trim(),
         Folder = items[2].Trim(),
         Doc = items[3].Trim(),
         FileName = items[4].Trim(), 
         NoOfAct = items[5].Trim(),   
       });
     // Now, it's quite easy to represent the data as we want.
     // And we want to *group by* `Folder` and `ID`: just one GroupBy operation
     var result = data
       .GroupBy(item => new {
          ID = item.Id, 
          Folder = item.Folder})  
       .Select(chunk => 
        $"File {chunk.Key.Folder + "_" + chunk.Key.Id}.txt :\r\n  {string.Join(Environment.NewLine + "  ", chunk.Select(item => item.Raw))}"); 
    foreach (var record in result) 
      Console.WriteLine(record);
