    	#region Data Access
	private string GetSettingsFromDb(string settingName)
	{
		return "";
	}
	private Dictionary<string,string> GetSettingsFromDb()
	{
		return new Dictionary<string, string>();
	}
	#endregion
	private const string KEY_SETTING1 = "Setting1";
	public string Setting1
	{
		get
		{
			if (Cache.Get(KEY_SETTING1) != null)
				return Cache.Get(KEY_SETTING1).ToString();
			Setting1 = GetSettingsFromDb(KEY_SETTING1);
			return Setting1;
		} 
		set
		{
			Cache.Remove(KEY_SETTING1);
			Cache.Insert(KEY_SETTING1, value, null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(2));
		}
	}
	private Cache Cache { get { return HttpContext.Current.Cache; } }
