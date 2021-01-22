    using System;
    using System.Xml;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ReandAndWriteXML
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			XDocument xdoc = XDocument.Load(@"file.xml");
    			var element = xdoc.Root.Elements("MyXmlElement").Single();
    			element.Value = "This wasn't nearly as hard as the internet tried to make it!";
    			xdoc.Save(@"file.xml");
    		}
    	}
    }
