    result = (from indexentry in source.Elements(entryLevel)
        select new IndexEntry
        {
            EtiologyCode = indexentry.Element("IE") == null 
                               ? null 
                               : indexentry.Element("IE").Value,
            //some code to set other properties in this object
            Note = indexentry.Elements("NO")
                             .Descendants()
                             .ConcatenateTextNodes()
        }
