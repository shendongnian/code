    static class Extensions
    {
        public static XElement ValidateXsd(this XElement source, string xsdPath)
        {
            var errors = new XElement("Errors");
            // Reference: http://msdn.microsoft.com/en-us/library/bb358456.aspx 
            var schemas = new XmlSchemaSet();
            using (var reader = XmlReader.Create(xsdPath))
            {
                schemas.Add("", reader);
            }
            var sourceQualifiedName = new XmlQualifiedName(source.Name.LocalName, source.Name.NamespaceName);
            source.Validate(
                schemas.GlobalElements[sourceQualifiedName],
                schemas,
                // Validation Event/Error Handling 
                (sender, e) =>
                {
                    var message =
                        e.Message.Replace(
                            "element is invalid - The value '' is invalid according to its datatype 'requiredString' - The actual length is less than the MinLength value.",
                            "cannot be blank.").Replace(
                            "is invalid according to its datatype 'size' - The Pattern constraint failed.",
                            "must be numeric.").Replace("element is invalid", "is invalid.");
                    errors.Add(new XElement("Error", message));
                });
            // If there were errors return them, otherwise return null 
            return errors.Elements().Count() > 0 ? errors : null;
        } 
    }
