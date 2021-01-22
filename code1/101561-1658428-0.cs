    var messages = new StringBuilder();
    var settings = new XmlReaderSettings { ValidationType = ValidationType.DTD };
    settings.ValidationEventHandler += (sender, args) => messages.AppendLine(args.Message);
    var reader = XmlReader.Create("file.xml", settings);
        
    if (messages.Length > 0)
    {
        // Log Validation Errors
        // Throw Exception
        // Etc.
    }
