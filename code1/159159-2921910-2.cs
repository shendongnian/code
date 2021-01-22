		public static bool? GetBool(ModelBindingContext bindingContext, string key)
		{
			var str = GetStr(bindingContext, key);
			bool tmp;
			if (string.IsNullOrEmpty(str))
				return null;
			str = str.ToLower().Trim();
			if (bool.TryParse(str, out tmp))
				return tmp;
			if (string.Compare(str, "no") == 0)
				return false;
			if (string.Compare(str, "yes") == 0)
				return true;
			if (string.Compare(str, "true,false") == 0)
				return true;
			return null;
		}
		public static string GetStr(ModelBindingContext bindingContext, string key)
		{
			if (string.IsNullOrEmpty(key))
				return null;
			var valueResult = bindingContext
				.ValueProvider
				.GetValue(bindingContext.ModelName + "." + key);
			if (valueResult == null && bindingContext.FallbackToEmptyPrefix)
				valueResult = bindingContext.ValueProvider.GetValue(key);
			return valueResult != null ? valueResult.AttemptedValue : null;
		}
