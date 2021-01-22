	public static class ObjectExtenders
	{
		static readonly ConditionalWeakTable<object, List<stringObject>> Flags = new ConditionalWeakTable<object, List<stringObject>>();
		public static string GetFlags(this object objectItem, string key)
		{
			return Flags.GetOrCreateValue(objectItem).Single(x => x.Key == key).Value;
		}
		public static void SetFlags(this object objectItem, string key, string value)
		{
			if (Flags.GetOrCreateValue(objectItem).Any(x => x.Key == key))
			{
				Flags.GetOrCreateValue(objectItem).Single(x => x.Key == key).Value = value;
			}
			else
			{
				Flags.GetOrCreateValue(objectItem).Add(new stringObject()
				{
					Key = key,
					Value = value
				});
			}
		}
		class stringObject
		{
			public string Key;
			public string Value;
		}
	}
