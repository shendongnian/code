       public class XmlConfigurator : IConfigurationSectionHandler
        {
            public object Create(object parent, 
                              object configContext, XmlNode section)
            {
                XPathNavigator xPN;
                if (section == null || (xPN = section.CreateNavigator()) == null ) 
                     return null;
                // ---------------------------------------------------------
                Type sectionType = Type.GetType((string)xPN.Evaluate
                                        ("string(@configType)"));
                XmlSerializer xs = new XmlSerializer(sectionType);
                return xs.Deserialize(new XmlNodeReader(section));
            }
        }
