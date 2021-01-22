		public static IEnumerable<T> AsEnumerable<T>(this object o) where T : class {
			var list = new List<T>();
			System.Reflection.PropertyInfo indexerProperty = null;
			foreach (System.Reflection.PropertyInfo pi in o.GetType().GetProperties()) {
				if (pi.GetIndexParameters().Length > 0) {
					indexerProperty = pi;
					break;
				}
			}
			if (indexerProperty.IsNotNull()) {
				var len = o.GetPropertyValue<int>("Length");
				for (int i = 0; i < len; i++) {
					var item = indexerProperty.GetValue(o, new object[]{i});
					if (item.IsNotNull()) {
						var itemObject = item as T;
						if (itemObject.IsNotNull()) {
							list.Add(itemObject);
						}
					}
				}
			}
			return list;
		}
    	public static bool IsNotNull(this object o) {
    		return o != null;
    	}
    	public static T GetPropertyValue<T>(this object source, string property) {
			if (source == null)
				throw new ArgumentNullException("source");
			var sourceType = source.GetType();
			var sourceProperties = sourceType.GetProperties();
			var properties = sourceProperties
				.Where(s => s.Name.Equals(property));
			if (properties.Count() == 0) {
				sourceProperties = sourceType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
				properties = sourceProperties.Where(s => s.Name.Equals(property));
			}
			if (properties.Count() > 0) {
				var propertyValue = properties
					.Select(s => s.GetValue(source, null))
					.FirstOrDefault();
				return propertyValue != null ? (T)propertyValue : default(T);
			}
			return default(T);
		}
