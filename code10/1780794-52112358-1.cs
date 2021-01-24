	public class LuisExtractionLuisResult
	{
		public List<LuisEntity> entities { get; set; }
	}
	public class LuisEntity
	{
		public string entity { get; set; }
		public string type { get; set; }
	}
