    string path = @"C:\Foo\Bar"; // your path goes here
    var dirInfo = new DirectoryInfo(path);
    var query = from f in dirInfo.GetFiles("*.xml")
                let split = f.Name.Split(new[] { ' ', '.' })
                select new 
                {
                    ObjectName = split[0],
                    Guid = split[1],
                    FileName = f.FullName
                };
    
    var results = query.GroupBy(o => o.ObjectName)
                       .Select(g => g.First());
                      
    foreach (var item in results)
    {
        Console.WriteLine(item.FileName);
        Console.WriteLine("ObjectName: {0} -- Guid {1}", item.ObjectName, item.Guid);
    }
