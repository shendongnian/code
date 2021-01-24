	[JsonProperty(PropertyName = "rows", NamingStrategyType = typeof(DefaultNamingStrategy), ItemTypeNameHandling = TypeNameHandling.None, TypeNameHandling = TypeNameHandling.None)]
	public IEnumerable<IDictionary<string, object>> Rows { get; set; }
	
	
	....
	[JsonProperty(PropertyName = "SessionData_Department")]
	public string sessionData_Department { get; set; }
	[JsonProperty(PropertyName = "SystemData_SerialNumber")]
	public string systemData_SerialNumber { get; set; }
	
