    private static Response DeserializeAndValidate(string tempFileName)
    {
        XmlSchemaSet schemas = new XmlSchemaSet();
        schemas.Add(LoadSchema());
        Exception firstException = null;
        var settings = new XmlReaderSettings
                       {
                           Schemas = schemas,
                           ValidationType = ValidationType.Schema,
                           ValidationFlags =
                               XmlSchemaValidationFlags.ProcessIdentityConstraints |
                               XmlSchemaValidationFlags.ReportValidationWarnings
                       };
        settings.ValidationEventHandler +=
            delegate(object sender, ValidationEventArgs args)
            {
                if (args.Severity == XmlSeverityType.Warning)
                {
                    Console.WriteLine(args.Message);
                }
                else
                {
                    if (firstException == null)
                    {
                        firstException = args.Exception;
                    }
                    Console.WriteLine(args.Exception.ToString());
                }
            };
        
        Response result;
        using (var input = new StreamReader(tempFileName))
        {
            using (XmlReader reader = XmlReader.Create(input, settings))
            {
                XmlSerializer ser = new XmlSerializer(typeof (Response));
                result = (Response) ser.Deserialize(reader);
            }
        }
        if (firstException != null)
        {
            throw firstException;
        }
        
        return result;
    }
