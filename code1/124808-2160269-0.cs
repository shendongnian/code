using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
namespace Testing.Xml
{
	class Program
	{
		static void Main(string[] args)
		{
			// read the schema
			XmlSchema schema;
        	using (var reader = new StreamReader(@"c:\path\to\schema.xsd"))
        	{
        		schema = XmlSchema.Read(reader, null);
        	}
        	
        	// compile so that post-compilation information is available
        	XmlSchemaSet schemaSet = new XmlSchemaSet();
			schemaSet.Add(schema);
        	schemaSet.Compile();
        	
        	// update schema reference
			schema = schemaSet.Schemas().Cast&lt;XmlSchema>().First();
			var simpleTypes = schema.SchemaTypes.Values.OfType&lt;XmlSchemaSimpleType>()
											   .Where(t => t.Content is XmlSchemaSimpleTypeRestriction);
											   
			foreach (var simpleType in simpleTypes)
			{
				var restriction = (XmlSchemaSimpleTypeRestriction) simpleType.Content;
				var enumFacets = restriction.Facets.OfType&lt;XmlSchemaEnumerationFacet>();
				
				if (enumFacets.Any())
				{
					Console.WriteLine("" + simpleType.Name);
					foreach (var facet in enumFacets)
					{
						Console.WriteLine(facet.Value);
					}
				}
			}
		}
	}
}
