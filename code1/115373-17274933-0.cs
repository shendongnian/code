        public static string GetObjectPropertyValue(object obj, string propertyName)
		{
			bool propertyHasDot = propertyName.IndexOf(".") > -1;
			string firstPartBeforeDot;
			string nextParts = "";
			if (!propertyHasDot)
				firstPartBeforeDot = propertyName.ToLower();
			else
			{
				firstPartBeforeDot = propertyName.Substring(0, propertyName.IndexOf(".")).ToLower();
				nextParts = propertyName.Substring(propertyName.IndexOf(".") + 1);
			}
			foreach (var property in obj.GetType().GetProperties())
				if (property.Name.ToLower() == firstPartBeforeDot)
					if (!propertyHasDot)
						if (property.GetValue(obj, null) != null)
							return property.GetValue(obj, null).ToString();
						else
							return DefaultValue(property.GetValue(obj, null), propertyName).ToString();
					else
						return GetObjectPropertyValue(property.GetValue(obj, null), nextParts);
			throw new Exception("Property '" + propertyName.ToString() + "' not found in object '" + obj.ToString() + "'");
		}
