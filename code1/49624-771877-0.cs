    using System.Linq;
    using System.Collections.Generic;
    
    List<string> unorderedList = List<string>();
    list.Add("3");
    list.Add("5");
    list.Add("2");
    list.Add("10");
    list.Add("-6");
    list.Add("7");
        
    List<string> orderedList = list.OrderBy(x => int.Parse(x)).ToList();
