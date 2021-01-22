    class CustomComparer : Comparer<string>
        {            
            public override int Compare(string a, string b)
            {   
                //Jamiec fixed the line below.             
                return a.Replace("_", "").CompareTo(b.Replace("_", ""));
            }
        }
    var customComparer = new CustomComparer();                                    
    var element = elements.OrderBy(c => c.elementName, customComparer);
