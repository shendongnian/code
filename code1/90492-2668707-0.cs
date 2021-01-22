	[XmlRoot(ElementName="product_root", DataType="product_type", 
	    Namespace="http://SchemaProvider.Example.org/Product.xsd",
	    IsNullable = false)]
	[XmlSchemaProviderAttribute("GetSchemaFile")]
	public class Product : IXmlSerializable
	{ 
	    public static XmlSchemaComplexType GetSchemaFile(
	        System.Xml.Schema.XmlSchemaSet xs)
	    {
	        string xsdFile = Directory.GetCurrentDirectory() + 
	            "\\Product.xsd";
	        XmlSerializer schemaSerializer = 
	            new XmlSerializer(typeof(XmlSchema));
	        XmlSchema schema = 
	            (XmlSchema)schemaSerializer.Deserialize(
	                XmlReader.Create(xsdFile));
	        xs.Add(schema);
	
	        // target namespace
	        string tns = "http://SchemaProvider.Example.org/Product.xsd";  
	        XmlQualifiedName name = 
	            new XmlQualifiedName("product_type", tns);
	        XmlSchemaComplexType productType = 
	            (XmlSchemaComplexType) schema.SchemaTypes[name];
	
	        return productType;
	    } 
	
	    ...
	}
