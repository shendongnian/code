		public string SoundFile
		{
			get
			{
				return ConfigurationManager.AppSettings["SoundFile"];
			}
			set
			{
				ConfigurationManager.AppSettings["SoundFile"] = value;
			}
		}
