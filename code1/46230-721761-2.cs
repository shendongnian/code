    		private class TargetProperty
		{
			public object Target { get; set; }
			public PropertyInfo Property { get; set; }
			public bool IsValid { get { return Target != null && Property != null; } }
		}
		private static TargetProperty GetTargetProperty(object source, string propertyName)
		{
			if (!propertyName.Contains("."))
				return new TargetProperty { Target = source, Property = source.GetType().GetProperty(propertyName) };
			string[] propertyPath = propertyName.Split('.');
			var targetProperty = new TargetProperty();
			targetProperty.Target = source;
			targetProperty.Property = source.GetType().GetProperty(propertyPath[0]);
			for (int propertyIndex = 1; propertyIndex < propertyPath.Length; propertyIndex++)
			{
				propertyName = propertyPath[propertyIndex];
				if (!string.IsNullOrEmpty(propertyName))
				{
					targetProperty.Target = targetProperty.Property.GetValue(targetProperty.Target, null);
					targetProperty.Property = targetProperty.Target.GetType().GetProperty(propertyName);
				}
			}
			return targetProperty;
		}
		public static bool HasProperty(this object source, string propertyName)
		{
			return GetTargetProperty(source, propertyName).Property != null;
		}
		public static object GetPropertyValue(this object source, string propertyName)
		{
			var targetProperty = GetTargetProperty(source, propertyName);
			if (targetProperty.IsValid)
			{
				return targetProperty.Property.GetValue(targetProperty.Target, null);
			}
			return null;
		}
		public static void SetPropertyValue(this object source, string propertyName, object value)
		{
			var targetProperty = GetTargetProperty(source, propertyName);
			if(targetProperty.IsValid)
			{
				targetProperty.Property.SetValue(targetProperty.Target, value, null);
			}
		}
