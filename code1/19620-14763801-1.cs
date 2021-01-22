	public abstract class ObjectWithDefaultValues : object {
		public ObjectWithDefaultValues () : this(true){
		}
		public ObjectWithDefaultValues (bool setDefaultValues) {
			if (setDefaultValues)
				this.SetDefaultValues();	
		}
	}
	public static class ObjectExtensions {
		public static void SetDefaultValues(this object obj) {
			foreach (FieldInfo f in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetField)) {
				foreach (Attribute attr in f.GetCustomAttributes(true)) {
					if (attr is DefaultValueAttribute) {
						var dv = (DefaultValueAttribute)attr;
						f.SetValue(obj, dv.Value);
					}
				}
			}
			foreach (var p in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty)) {
				if (p.GetIndexParameters().Length == 0) {
					foreach (Attribute attr in p.GetCustomAttributes(true)) {
						if (attr is DefaultValueAttribute) {
							var dv = (DefaultValueAttribute)attr;
							p.SetValue(obj, dv.Value, null);
						}
					}
				}
			}
		}
	}
