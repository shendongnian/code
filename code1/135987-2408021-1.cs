    Stream stream = new MemoryStream(Encoding.UTF8.GetBytes("<YourXml />"));
    var input = mappingAssembly.GetManifestResourceStream(
                "MySchema.xsd"
                ); //This could be whatever resource your schema is           
    var schemas = new XmlSchemaSet();            
    schemas.Add(
       "urn:YourSchemaUrn",
       XmlReader.Create(
          input
          )
     );
    var settings = new XmlReaderSettings
                               {
                                   ValidationType = ValidationType.Schema,
                                   Schemas = schemas
                               };
    settings.ValidationEventHandler += MakeAHandlerToHandleAnyErrors;
    var reader = XmlReader.Create(stream, settings);
    while (reader.Read()) {} //Makes it read to the end, therefore validates
