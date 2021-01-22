        static string FixSavedXaml(string xaml)
        {
            bool isFixed = false;
            var xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.LoadXml(xaml);
            FixSavedXmlElement(xmlDocument.DocumentElement, ref isFixed);
            if (isFixed) // Only bothering with generating new xml if something was fixed
            {
                StringBuilder xmlStringBuilder = new StringBuilder();
                var settings = new System.Xml.XmlWriterSettings();
                settings.Indent = false;
                settings.OmitXmlDeclaration = true;
                using (var xmlWriter = System.Xml.XmlWriter.Create(xmlStringBuilder, settings))
                {
                    xmlDocument.Save(xmlWriter);
                }
                return xmlStringBuilder.ToString();
            }
            return xaml;
        }
        static void FixSavedXmlElement(System.Xml.XmlElement xmlElement, ref bool isFixed)
        {
            // Empty strings are written as self-closed element by XamlWriter,
            // and the XamlReader can not handle this because it can not find an empty constructor and throws an exception.
            // To fix this we change it to use start and end tag instead (by setting IsEmpty to false on the XmlElement).
            if (xmlElement.LocalName == "String" &&
                xmlElement.NamespaceURI == "clr-namespace:System;assembly=mscorlib")
            {
                xmlElement.IsEmpty = false;
                isFixed = true;
            }
            foreach (var childElement in xmlElement.ChildNodes.OfType<System.Xml.XmlElement>())
            {
                FixSavedXmlElement(childElement, ref isFixed);
            }
        }
