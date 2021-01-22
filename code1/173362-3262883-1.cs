    XDocument doc = XDocument.Parse(@"<Properties>
                    <Property name='ID'>10000</Property>
                    <Property name='Name'>
                        <SubProperty name='FirstName'>Foo</SubProperty>
                        <SubProperty name='LastName'>Bar</SubProperty>
                    </Property>
                </Properties>");
    
    XElement items = new XElement("Items", 
    							   from property in doc.Descendants("Property")
    							   select new XElement((string)property.Attribute("name"),
    													// If there are no child elements (SubPropety)
    													// get the property value
    													property.HasElements ? null : (string)property,
    													// Another way for checking if there are any child elements
    													// You could also use property.HasElements like the previous statement
    													property.Elements("SubProperty").Any() ?
    													from subproperty in property.Elements("SubProperty")
    													select new XElement((string)subproperty.Attribute("name"),
    																		(string)subproperty) : null)
															
							  );
