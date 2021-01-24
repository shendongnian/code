    // get the column names
    var keys = mainObj.information.report
                  .SelectMany(x => x.Keys)
                  .Distinct()
                  .OrderBy(key => key)
                  .ToList();
    // print the column headers
    keys.ForEach(key => Console.Write(columnFormat, key));
    Console.WriteLine();
    // print the rows
    foreach (var report in mainObj.information.report)
    {
        keys.ForEach(key =>
        {
            string value;
            report.TryGetValue(key, out value);
            Console.Write(columnFormat, value);
        });
        Console.WriteLine();
    }
