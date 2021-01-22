        public static class AssemblyExtensions
        {
            public static string InfoToXML(this Assembly assembly)
            {
                string name = assembly.FullName;
                string title = String.Empty;
                string description = String.Empty;
                string company = String.Empty;
                string culture = String.Empty;
                string configuration = String.Empty;
                string version = String.Empty;
                string informationalVersion = String.Empty;
                string product = String.Empty;
                string trademark = String.Empty;
                string copyright = String.Empty;
    
                foreach (var attrib in assembly.GetCustomAttributes(false))
                {
                    if (attrib is AssemblyTitleAttribute)
                    {
                        title = ((AssemblyTitleAttribute)attrib).Title;
                    }
    
                    if (attrib is AssemblyDescriptionAttribute)
                    {
                        description = ((AssemblyDescriptionAttribute)attrib).Description;
                    }
    
                    if (attrib is AssemblyCompanyAttribute)
                    {
                        company = ((AssemblyCompanyAttribute)attrib).Company;
                    }
    
                    if (attrib is AssemblyCultureAttribute)
                    {
                        culture = ((AssemblyCultureAttribute)attrib).Culture;
                    }
    
                    if (attrib is AssemblyConfigurationAttribute)
                    {
                        configuration = ((AssemblyConfigurationAttribute)attrib).Configuration;
                    }
    
                    if (attrib is AssemblyVersionAttribute)
                    {
                        version = ((AssemblyVersionAttribute)attrib).Version;
                    }
    
                    if (attrib is AssemblyInformationalVersionAttribute)
                    {
                        informationalVersion = ((AssemblyInformationalVersionAttribute)attrib).InformationalVersion;
                    }
    
                    if (attrib is AssemblyProductAttribute)
                    {
                        product = ((AssemblyProductAttribute)attrib).Product;
                    }
    
                    if (attrib is AssemblyTrademarkAttribute)
                    {
                        trademark = ((AssemblyTrademarkAttribute)attrib).Trademark;
                    }
    
                    if (attrib is AssemblyCopyrightAttribute)
                    {
                        copyright = ((AssemblyCopyrightAttribute)attrib).Copyright;
                    }
                }
    
                StringBuilder builder = new StringBuilder();
                StringWriter stringWriter = new StringWriter(builder);
                XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);
    
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("AssemblyInformation");
                xmlWriter.WriteElementString("AssemblyName", name);
                xmlWriter.WriteElementString("Title", title);
                xmlWriter.WriteElementString("Description", description);
                xmlWriter.WriteElementString("Company", company);
                xmlWriter.WriteElementString("Culture", culture);
                xmlWriter.WriteElementString("Configuration", configuration);
                xmlWriter.WriteElementString("Version", version);
                xmlWriter.WriteElementString("InformationalVersion", informationalVersion);
                xmlWriter.WriteElementString("Product", product);
                xmlWriter.WriteElementString("Trademark", trademark);
                xmlWriter.WriteElementString("Copyright", copyright);
                xmlWriter.WriteEndElement();
    
                return builder.ToString();
            }
        }
