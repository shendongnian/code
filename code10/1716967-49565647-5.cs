    public abstract class DefaultedObject<T>
    {
		protected DefaultedObject()
		{
			T defaultValue = Default;
			FieldInfo[] fields = GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			foreach(FieldInfo field in fields) {
				if(field.FieldType == typeof(T)) {
					field.SetValue(this, defaultValue);
				}
			}
		}
		protected abstract T Default { get; }
    }
