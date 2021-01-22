    //Dommer's example, using data.xml from OP
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    class loadXMLToLINQ
    {
    static void Main( )
    	{
    		XElement rootElement = XElement.Load(@"c:\\data.xml"); //you'll have to edit your path
    		Console.WriteLine(GetOutline(0, rootElement));  
    	}
    
    static private string GetOutline(int indentLevel, XElement element)
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
    }
