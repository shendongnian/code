    var root = XElement.Parse(xml);
    var result = new XElement("Items");
    foreach (var p in root.Descendants("Property")) 
    {
     var subs =  p.Descendants("SubProperty").Select( sp => Transpose(sp) );
        // The trick is here - XElement constructor uses params object[], 
        // so we can pass an arbitrary number of arguments to build the XElement
     var item = new XElement( p.Attribute("name").Value, subs, subs.Any() : null ? p.Value );
     
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
        <LastName>Bar</LastName>
      </Name>
    </Items>
