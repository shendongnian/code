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
                                      select (ElementWithPrefix(i, '*'))).ToList()
                      }).ToList();
            return result;
        }
        string ElementWithPrefix(XElement element, char c)
        {
            string prefix = "";
            for (XElement e = element.Parent; e.Name == "I"; e = e.Parent)
            {
                prefix += c;
            }
            return prefix + ExtractTextValue(element);
        }
        string ExtractTextValue(XElement element)
        {
            if (element.HasElements)
            {
                return element.Value.Split(new[] { '<' })[0].Trim();
            }
            else
                return element.Value.Trim();
        }
