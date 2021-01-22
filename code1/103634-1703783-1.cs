    void Main()
    {
    	XDocument settingsXML = XDocument.Load(@"c:\temp\settings.xml");
    	XDocument updateXML = XDocument.Load(@"c:\temp\updates.xml");
    
    	Console.WriteLine("Processing");
    
    	// Loop through the updates
    	foreach(XElement update in updateXML.Element("preset").Elements("var"))
    	{    
    		// Find the element to update    
    		XElement settingsElement = (from s in settingsXML.Element("preset").Elements("var")
    									where s.Attribute("id").Value == update.Attribute("id").Value &&
    									s.Attribute("opt").Value == update.Attribute("opt").Value
    									select s).FirstOrDefault();    
    		if (settingsElement != null)    
    		{      
    			settingsElement.Attribute("val").Value = update.Attribute("val").Value;    
    		}    
    		else    
    		{   
    			// not found handling    
    			Console.WriteLine("Not found {0},{1}", update.Attribute("id").Value, update.Attribute("opt").Value);
    		}
    	}
    	Console.WriteLine("Saving");
    	settingsXML.Save(@"c:\temp\updatedSettings.xml");
    	Console.WriteLine("Finis!");
    }
