    public static class ObjectExtensions {
        public static string GetPropertyNameAndValue<T>(this T obj, out object value) {
			System.Reflection.PropertyInfo[] objGetTypeGetProperties = obj.GetType().GetProperties();
			if(objGetTypeGetProperties.Length == 1) {
				value = objGetTypeGetProperties[0].GetValue(obj, null);
				return objGetTypeGetProperties[0].Name;
			} else
				throw new ArgumentException("object must contain one property");
		}
    }
    class Whatever {
	 protected void ChangeProperty<T>(object property, T newValue, Action change) {
		 object value;
		 var name = property.GetPropertyNameAndValue(out value);
		 if(value == null && newValue != null || value != null && !value.Equals(newValue)) {
		     change();
		     OnPropertyChanged(name);
		 }
	 }
	 private string m_Title;
	 public string Title {
		 get { return m_Title; }
		 set {
			 ChangeProperty(new { Title }, value, () => m_Title = value); 
		 }
	 }
    }
