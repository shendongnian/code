    var groupedByHash = from kvp in dict
                        group kvp by kvp.Value into grp
                        let count = grp.Count()
                        where count > 1
                        select grp;
    foreach (IGrouping<string,KeyValuePair<string,string>> grp in groupedByHash)
    {
        Console.WriteLine("Hashcode : {0}", grp.Key);
        foreach(KeyValuePair<string,string> kvp in grp)
        {
            Console.WriteLine("\tFilename = {0}", kvp.Key);
        }
        Console.WriteLine();
    }
