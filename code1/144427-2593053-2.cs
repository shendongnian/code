	class Preferences
	{
		private const string filePreferences = "preferences.xml";
		public Preferences() { }
		public static Preferences Load()
		{
			Preferences pref = null;
			if (File.Exists(Preferences.FileFullPath))
			{
				var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Preferences));
				using (var xmlReader = new System.Xml.XmlTextReader(Preferences.FileFullPath))
				{
					if (serializer.CanDeserialize(xmlReader))
					{
						pref = serializer.Deserialize(xmlReader) as Preferences;
					}
				}
			}
			return ((pref == null) ? new Preferences() : pref);
		}
		public void Save()
		{
			var preferencesFile = FileFullPath;
			var preferencesFolder = Directory.GetParent(preferencesFile).FullName;
			using (var fileStream = new FileStream(preferencesFile, FileMode.Create))
			{
				new System.Xml.Serialization.XmlSerializer(typeof(Preferences)).Serialize(fileStream, this);
			}
		}
	}
