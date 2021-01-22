    foreach (XElement child in e.Elements("BANNER"))
                {
    
                    IEnumerable<XElement> groups = child.Descendants("BANNER_TEXTS").ElementAt(0).Descendants("BANNER_TEXT");
    
                    var groupCats =
                    from s in groups
                    group s by s.Value into grouped
                    select new
                    {
                        GroupCategory = grouped.Key,
                        Categories = GetCategories(grouped.Key, child)
                    };
                }
    
     private IEnumerable<string> GetCategories(string key, XElement parent)
        {
            int span = parent.Descendants("BANNER_TEXTS").ElementAt(0).Descendants("BANNER_TEXT").Where(x => x.Value == key).Select(x => int.Parse(x.Attribute("SPAN_COL").Value)).FirstOrDefault();
            IEnumerable<int> set = Series(key,parent.Descendants("BANNER_TEXTS").ElementAt(0).Descendants("BANNER_TEXT"));
            int sum = set.Sum();        
            return parent.Descendants("BANNER_TEXTS").ElementAt(1).Descendants("BANNER_TEXT").Skip(sum).Take(span).Select(x => x.Value);
    
        }
    
        private static IEnumerable<int> Series(string key, IEnumerable<XElement> elements)
        {
                  
            foreach (XElement item in elements)
            {
                if (item.Value != key)
                {
                    yield return int.Parse(item.Attribute("SPAN_COL").Value);
    
                }
                else
                {
                    break;
                }
    
            }
    
        }
