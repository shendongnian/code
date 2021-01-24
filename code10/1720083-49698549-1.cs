    var data = 
    @"<example>
    <someElement
      someAttribute=""val"">
      
      </someElement></example>
    ";
    
    var doc = XDocument.Load(new MemoryStream(Encoding.UTF8.GetBytes(data)), LoadOptions.SetLineInfo);
    foreach(var element in doc.Descendants()) {
    	var elLineInfo = element as IXmlLineInfo;
    	Console.Out.WriteLine(
    		$"Element '{element.Name}' at {elLineInfo.LineNumber}:{elLineInfo.LinePosition}");
    
    	
    	foreach(var attr in element.Attributes()) {
    		var attrLineInfo = attr as IXmlLineInfo;
    		Console.Out.WriteLine(
    			$"Attribute '{attr.Name}' at {attrLineInfo.LineNumber}:{attrLineInfo.LinePosition}");
    	}
    }
