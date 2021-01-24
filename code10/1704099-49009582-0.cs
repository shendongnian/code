    var groupedTocs = li.GroupBy(toc => toc.Part);
    foreach(var part in groupedTocs)
    {
        Console.WriteLine(part.Key);
        foreach(var chapter in part)
        {
            Console.WriteLine($"\t{chapter.Header}");
        }
    }
