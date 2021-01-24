	public class Key
	{
		private readonly string Property1;
		private readonly string Property2;
		private readonly string Property3 = "!";
		
		public Key(Dictionary<string, object> config)
		{
			if (config == null)
			{
				return;
			}
		
			var type = typeof(Key);
			var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
			foreach (string name in config.Keys)
			{
				var field = fields.Where(f => f.Name == name).SingleOrDefault();
				if (field == null)
				{
					continue;
				}
				
				field.SetValue(this, config[name]);
			}
		}
		
		public string GetValues()
		{
			return Property1 + Property2 + Property3;
		}
	}
