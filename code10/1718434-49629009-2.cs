    void Main()
    {
        string xml1 =
    @"<ROOT>
      <Columns BaseXPath=""//Orders/Position/"">
        <Colum XPath=""@PositionSK"" Name=""Position""/>
        <Colum XPath=""@PosGroup"" Name=""Gruppen-Nr""/>
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
    
        var basePath = schemaDoc.Descendants("Columns").FirstOrDefault().Attribute("BaseXPath").Value;
        // XPATH isn't supposed to end with a trailing "/".
        if (basePath.EndsWith("/"))
        {
            basePath = basePath.Substring(0, basePath.Length - 1);
        }
        var lines = dataDoc.XPathSelectElements(basePath);
    
        var rowIndex = 0;
        foreach (var line in lines)
        {
            Console.WriteLine($"---Row {rowIndex}");
            foreach (var col in schemaDoc.Descendants("Colum"))
            {
                var columnName = col.Attribute("Name").Value;
                Console.Write($"{columnName}: ");
    
                var columnValue = ((XAttribute)((IEnumerable<Object>)line.XPathEvaluate(col.Attribute("XPath").Value)).FirstOrDefault()).Value;
                Console.WriteLine(columnValue);
            }
    
            Console.WriteLine();
            rowIndex++;
        }
    }
