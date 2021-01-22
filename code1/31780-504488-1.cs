        List<TabularEntry> GetTabularEntries(XElement source)
        {
            List<TabularEntry> result;
            result = (from tabularentry in source.Elements()
                      select new TabularEntry()
                      {
                          Tag = tabularentry.Name.ToString(),
                          Description = tabularentry.Element("DX").ToString(),
                          Code = tabularentry.FirstNode.ToString(),
                          UseNote = tabularentry.Element("UN") == null ? null : tabularentry.Element("UN").Value,
                          Excludes = (from i in tabularentry.Element("EX").Descendants("I")
                                      select (i.Parent.Name == "I" ? "*" + i.Value : i.Value)).ToList()
                      }).ToList();
            return result;
        }
