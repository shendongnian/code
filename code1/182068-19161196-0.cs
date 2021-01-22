	public class NameValueCollectionConfigurationSection : ConfigurationSection
	{
		private const string COLLECTION_PROP_NAME = "";
		public IEnumerable<KeyValuePair<string, string>> GetNameValueItems()
		{
			foreach ( string key in this.ConfigurationCollection.AllKeys )
			{
				NameValueConfigurationElement confElement = this.ConfigurationCollection[key];
				yield return new KeyValuePair<string, string>
					(confElement.Name, confElement.Value);
			}
		}
		[ConfigurationProperty(COLLECTION_PROP_NAME, IsDefaultCollection = true)]
		public NameValueConfigurationCollection ConfCollection
		{
			get
			{
				return (NameValueConfigurationCollection) base[COLLECTION_PROP_NAME];
			}
		}
