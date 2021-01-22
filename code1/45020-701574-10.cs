    result = (from indexentry in source.Elements(entryLevel)
        select new IndexEntry
        {
            EtiologyCode = indexentry.Element("IE") == null 
                               ? null 
                               : indexentry.Element("IE").Value,
            //some code to set other properties in this object
            Note = string.Join(" ", indexentry.Elements("NO")
                                              .Descendants()
                                              .Select(x => x.Value)
                                              .ToArray())
        };
