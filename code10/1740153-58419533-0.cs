 lang-cs
void Main()
{
    var generator = new JSchemaGenerator();
    generator.ContractResolver = new CamelCasePropertyNamesContractResolver();
    generator.SchemaIdGenerationHandling = SchemaIdGenerationHandling.TypeName;
    var schema = generator.Generate(typeof(myType));
    RejectAdditionalProperties(schema);
    string jsonSchema = schema.ToString();
}
static void RejectAdditionalProperties(JSchema schema)
{
    schema.AllowAdditionalProperties = false;
    foreach(var s in schema.Properties.Values) RejectAdditionalProperties(s);
}
