		public static string[] AllDescription(this Type enumType)
		{
			if (!enumType.IsEnum) return null;
		
			var list = new List<string>();
			var values = Enum.GetValues(enumType);
			foreach (var item in values)
			{
				// add any combination of information to list here:
				list.Add(string.Format("{0}", item));
				//this one gets the values from the [Description] Attribute that I usually use to fill drop downs
				//list.Add(((Enum) item).GetDescription());
			}
			return list.ToArray();
		}
