    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
      public static void Main()
      {
        var DictB = new Dictionary<string,List<string>>();
        var DictA = new Dictionary<string,string>();
        DictB.Add("abc", new List<string>() {"123","456"});
        DictA.Add("456","foo");
        DictA.Add("123","bar");
        var res = from kvp2 in DictB
                   from kvp2v in kvp2.Value
                   join kvp3 in DictA 
                   on kvp2v equals kvp3.Key
                   select new {Column1 = kvp2.Key, Column2 = kvp2v, Column3 = kvp3.Value};
        
        foreach ( var item in res) Console.WriteLine(item);
      }
    
    }
