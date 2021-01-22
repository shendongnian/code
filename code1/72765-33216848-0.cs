    using System.Configuration;
    using System.Xaml;
    using System.Xml;
    ...
    public class XamlConfigurationSection<T> : ConfigurationSection
	{
		public static XamlConfigurationSection<T> Get(string sectionName)
		{
			return (XamlConfigurationSection<T>)ConfigurationManager.GetSection(sectionName);
		}
		public T Content { get; set; }
		protected override void DeserializeSection(XmlReader xmlReader)
		{
			xmlReader.Read();
			using (var xamlReader = new XamlXmlReader(xmlReader))
				Content = (T)XamlServices.Load(xamlReader);
		}
	}
