    string path = @"C:\Foo\Bar"; // your path goes here
    var dirInfo = new DirectoryInfo(path);
    // DirectoryInfo.GetFiles() returns an array of FileInfo[]
    // FileInfo's Name property gives us the file's name without the full path
    // LINQ let statement stores the split result, splitting the filename on spaces
    // and dots to get the objectName, and Guid separated from the file extension.
    // The "select new" projects the results into an anonymous type with the specified
    // properties and respectively assigned values. I stored the fullpath just in case.
    var query = from f in dirInfo.GetFiles("*.xml")
                let split = f.Name.Split(new[] { ' ', '.' })
                select new 
                {
                    ObjectName = split[0],
                    Guid = split[1],
                    FileName = f.FullName
                };
    
    // Now that the above query has neatly separated the ObjectName, we use LINQ
    // to group by ObjectName (the group key). Multiple files may exist under the same
    // key so we then select the First item from each group.
    var results = query.GroupBy(o => o.ObjectName)
                       .Select(g => g.First());
                      
    // Iterate over the results using the projected property names.
    foreach (var item in results)
    {
        Console.WriteLine(item.FileName);
        Console.WriteLine("ObjectName: {0} -- Guid {1}", item.ObjectName, item.Guid);
    }
