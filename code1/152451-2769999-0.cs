    foreach (XElement child in e.Elements("{wincross.xsl}BANNER"))
                {
    
                    IEnumerable<XElement> groups = child.Descendants("{wincross.xsl}BANNER_TEXTS").ElementAt(0).Descendants("{wincross.xsl}BANNER_TEXT");//.Where(x => !string.IsNullOrEmpty(x.Value));
    
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
            int span = parent.Descendants("{wincross.xsl}BANNER_TEXTS").ElementAt(0).Descendants("{wincross.xsl}BANNER_TEXT").Where(x => x.Value == key).Select(x => int.Parse(x.Attribute("SPAN_COL").Value)).FirstOrDefault();
            IEnumerable<int> set = Series(key,parent.Descendants("{wincross.xsl}BANNER_TEXTS").ElementAt(0).Descendants("{wincross.xsl}BANNER_TEXT"));
            int sum = set.Sum();        
            return parent.Descendants("{wincross.xsl}BANNER_TEXTS").ElementAt(1).Descendants("{wincross.xsl}BANNER_TEXT").Skip(sum).Take(span).Select(x => x.Value);
    
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
