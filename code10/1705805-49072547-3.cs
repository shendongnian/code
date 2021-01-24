    string s = @"<items>
        <item id='0001' type='donut'>
            <name>Cake</name>
            <ppu>0.55</ppu>
            <batters>
               <batter id='1001'>Regular</batter> is good <ax>1023</ax> and <batter id='1002'>Chocolate</batter> or maybe <batter id='1003'>Blueberry</batter>
    		   </batters>
            <topping id='5001'>None</topping>
            <topping id='5002'>Glazed</topping>
            <topping id='5005'>Sugar</topping>
            <topping id='5006'>Sprinkles</topping>
            <topping id='5003'>Chocolate</topping>
            <topping id='5004'>Maple</topping>
        </item>
    </items>";
    
    var yourNodes = XDocument.Parse(s)
       .Descendants("batters").Nodes()
       .Where(a=> 
           a.NodeType == XmlNodeType.Text || // take all text nodes
           // or elements that are not "batter".
           (a.NodeType == XmlNodeType.Element && ((XElement)a).Name 
    != "batter"));
    
    string concatenated = yourNodes.Select(a=>a.ToString()).Aggregate((a,b)=>a+b);
