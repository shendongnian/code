    public class XmlConfigurator : IConfigurationSectionHandler
        {
            public object Create(object parent, object configContext, XmlNode section)
            {
                if (section == null) return null;
                Type sectionType = Type.GetType((string)(section.CreateNavigator()).Evaluate("string(@configType)"));
                XmlSerializer xs = new XmlSerializer(sectionType);
                return xs.Deserialize(new XmlNodeReader(section));
            }
        }
