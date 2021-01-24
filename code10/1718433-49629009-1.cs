    void Main()
    {
        string xml1 =
    @"<ROOT>
      <Columns BaseXPath=""//Orders/Position/"">
        <Colum XPath=""@PositionSK"" Name=""Position""/>
        <Colum XPath=""@PosGroup"" Name=""Gruppen-Nr""/>
        ---Lines truncated to keep this example short--
      </Columns>
    </ROOT>";
    
        string data =
    @"<Set>
        <Orders>
            <Position PositionSK=""A"" PosGroup=""1"" SomeOtherAttribute=""ABC"" />
            <Position PositionSK=""B"" PosGroup=""2"" SomeOtherAttribute=""DEF"" />
        </Orders>
    </Set>";
    
        var schemaDoc = XDocument.Parse(xml1);
        var dataDoc = XDocument.Parse(data);
    
        var itemsXPath = schemaDoc.Descendants("Columns").FirstOrDefault()?.Attribute("BaseXPath").Value;
        var lines = dataDoc.XPathSelectElements($"//Orders/Position");
    
        var rowIndex = 0;
        foreach (var line in lines)
        {
            Console.WriteLine($"---Row {rowIndex}");
            foreach (var col in schemaDoc.Descendants("Colum")) // This is NOT optimal.  You should probably extract this to a list outside the loop.
            {
                Console.Write($"{col.Attribute("Name").Value}: ");
                Console.WriteLine(((XAttribute)((IEnumerable<Object>)line.XPathEvaluate(col.Attribute("XPath").Value)).FirstOrDefault()).Value);
            }
            
            Console.WriteLine();
            rowIndex++;
        }
    }
