	private sealed class BlobStorageConfiguration : IConfiguration
	{
		private readonly string _bsConnString;
		public BlobStorageConfiguration(string connString)
		{
			_bsConnString = connString;
		}
		public string this[string key]
		{
			get => key == "Storage" ? _bsConnString : null;
			set { }
		}
		public IEnumerable<IConfigurationSection> GetChildren() => null;
		public IChangeToken GetReloadToken() => null;
		public IConfigurationSection GetSection(string key) => null;
	}
