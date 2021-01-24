    public class BaseClass : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
            {
                XmlElementAttribute elementAttribute = propertyInfo.GetCustomAttribute<XmlElementAttribute>(true);
                if (elementAttribute != null)
                {
                    string[] elementNames = elementAttribute.ElementName.Split('/', '\\');
                    foreach (string elementName in elementNames)
                    {
                        reader.ReadStartElement(elementName);
                    }
                    propertyInfo.SetValue(this, reader.ReadContentAsString());
                    foreach (string elementName in elementNames)
                    {
                        reader.ReadEndElement();
                    }
                }
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
            {
                XmlElementAttribute elementAttribute = propertyInfo.GetCustomAttribute<XmlElementAttribute>(true);
                if (elementAttribute != null)
                {
                    string[] elementNames = elementAttribute.ElementName.Split('/', '\\');
                    foreach (string elementName in elementNames)
                    {
                        writer.WriteStartElement(elementName);
                    }
                    writer.WriteString(propertyInfo.GetValue(this).ToString());
                    foreach (string elementName in elementNames)
                    {
                        writer.WriteEndElement();
                    }
                }
            }
        }
        protected string GetProperty(Func<string> f)
        {
            return "text-value";
        }
        protected void SetProperty<T>(Func<T> f, T value)
        {
        }
    }
