    class CustomComparer : Comparer<string>
        {            
            public override int Compare(string a, string b)
            {
                a.Replace("_", "");
                b.Replace("_", "");
                return a.CompareTo(b);
            }
        }
    var customComparer = new CustomComparer();                                    
    var element = elements.OrderBy(c => c.elementName, customComparer);
