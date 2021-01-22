    using System.Xml.Linq;
    void Main()
    {
        StringBuilder result = new StringBuilder();
    
        //Load xml
        XDocument xdoc = XDocument.Load("data.xml");
    
        //Run query
        var lv1s = from lv1 in xdoc.Descendants("level1")
                   select new { 
                       Header = lv1.Attribute("name").Value,
                       Children = lv1.Descendants("level2")
                   };
        
        //Loop through results
        foreach (var lv1 in lv1s){
                result.AppendLine(lv1.Header);
                foreach(var lv2 in lv1.Children)
                     result.AppendLine("     " + lv2.Attribute("name").Value);
        }
    	
        Console.WriteLine(result);
    }
