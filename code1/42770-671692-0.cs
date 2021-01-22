    void Main()
    {
        XElement rootElement = XElement.Load(@"c:\events\test.xml");
		
        Console.WriteLine(GetOutline(0, rootElement));	
    }
    private string GetOutline(int indentLevel, XElement element)
    {
        StringBuilder result = new StringBuilder();
        if (element.Attribute("name") != null)
        {
            result = result.AppendLine(new string(' ', indentLevel * 2) + element.Attribute("name").Value);
        }
        foreach (XElement childElement in element.Elements())
        {
            result.Append(GetOutline(indentLevel + 1, childElement));
        }
	
        return result.ToString();
    }
