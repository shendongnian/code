    var root = XElement.Parse(xml);
    var result = new XElement("Items");
    foreach (var p in root.Descendants("Property")) 
    {
    	var subs =  p.Descendants("SubProperty").Select( sp => Transpose(sp) );
    	var item = new XElement( p.Attribute("name").Value, subs, p.Value );
    	result.Add( item );
    }
    // Transpose method
    XElement Transpose(XElement xe)
    {
    	return new XElement( xe.Attribute("name").Value, xe.Value );
    }
    // result
    <Items>
      <ID>10000</ID>
      <Name>
        <FirstName>Foo</FirstName>
        <LastName>Bar</LastName>FooBar</Name>
      <Address>
        <Street>The Street</Street>
        <Number>123</Number>The Street123</Address>
    </Items>
