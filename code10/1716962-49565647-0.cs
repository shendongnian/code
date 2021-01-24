    public abstract class DefaultedObject<T>
    {
		protected DefaultedObject()
		{
			PropertyInfo[] properties = GetType().GetProperties();
			T defaultValue = Default();
			foreach(PropertyInfo property in properties) {
				if(property.PropertyType == typeof(T)) {
					property.SetValue(this, defaultValue);
				}
			}
		}
		protected abstract T Default();
    }
