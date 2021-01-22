		public static T FindNestedPropertyValue<T, N>(N model, string propName) {
			T retVal = default(T);
			bool found = false;
			PropertyInfo[] properties = typeof(N).GetProperties();
			foreach (PropertyInfo property in properties) {
				var currentProperty = property.GetValue(model, null);
				if (!found) {
					try {
						retVal = GetPropValue<T>(currentProperty, propName);
						found = true;
					} catch { }
				}
			}
			if (!found) {
				throw new Exception("Unable to find property: " + propName);
			}
			return retVal;
		}
    		public static T GetPropValue<T>(object srcObject, string propName) {
			return (T)srcObject.GetType().GetProperty(propName).GetValue(srcObject, null);
		}
