    public static class ConfigurationSectionExtensions
    {
        public static T GetAs<T>(this ConfigurationSection section)
        {
            var sectionInformation = section.SectionInformation;
            var sectionHandlerType = Type.GetType(sectionInformation.Type);
            if (sectionHandlerType == null)
            {
                throw new InvalidOperationException(string.Format("Unable to find section handler type '{0}'.", sectionInformation.Type));
            }
            IConfigurationSectionHandler sectionHandler;
            try
            {
                sectionHandler = (IConfigurationSectionHandler)Activator.CreateInstance(sectionHandlerType);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidOperationException(string.Format("Section handler type '{0}' does not implement IConfigurationSectionHandler.", sectionInformation.Type), ex);
            }
            var rawXml = sectionInformation.GetRawXml();
            if (rawXml == null)
            {
                return default(T);
            }
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(rawXml);
            return (T)sectionHandler.Create(null, null, xmlDocument.DocumentElement);
        }
    }
