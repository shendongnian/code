    XDocument schema = XDocument.Load(xsdPath);
            XNamespace xs = schema.Root?.Name.Namespace;
            var enumerations = schema
                .Root?
                .Descendants(xs + "simpleType")
                .Where(t => (string) t.Attribute("name") == simpleTypeName)
                .Descendants(xs + "enumeration")
                .ToList();
            foreach (var element in enumerations)
            {
                var annotation = element.Elements().ElementAt(0);
                var documentationElement = annotation.Elements().ElementAt(0);
                //
                var nameValue = documentationElement.Elements().ElementAt(0).Value;
                var decsValue = documentationElement.Elements().ElementAtOrDefault(1)?.Value;
                addMethod.Invoke(nameValue, decsValue);
            }
