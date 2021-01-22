    var groups = from f in System.IO.Directory.GetFiles("DirectoryPath", "*.zip")
                 group f by f.Split('_')[0] into g
                 select new {
                     GUID = g.Key
                     Count = g.Count()
                 };
    foreach(var group in groups) {
        Console.WriteLine("Guid = {0}: Count = {1}", group.GUID, group.Count);
    }
