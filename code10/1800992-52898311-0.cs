	public class MyRequestISchemaFilter : ISchemaFilter
	{
		public void Apply(Schema schema, SchemaFilterContext context)
		{
			if (schema.Type == "object"){
				if (context.SystemType == typeof(test_c))
				{
					schema.Xml = new Xml()
					{
						Namespace = "http://www.example.com/ns/v1"
					};
					foreach (var prop in schema.Properties)
					{
						if (prop.Key == "tc1")
						{
							prop.Value.Xml = new Xml()
							{
								Name = "my-new-name"
							};
						}
					}
				}
			}
		}
	}
