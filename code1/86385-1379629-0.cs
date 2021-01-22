    public class Test {
        public int Number { get; set; }
        public void SetNumberUsingReflection(object newValue) {
            Number = 99;
            Type type = GetType();
            PropertyInfo propertyInfo = type.GetProperty("Number");
    		if(propertyInfo.PropertyType.IsValueType && newValue == null) {
    			throw new InvalidOperationException(String.Format("Cannot set a property of type '{0}' to null.", propertyInfo.PropertyType));
    		} else {
    			propertyInfo.SetValue(this, newValue, null);
    		}
        }
    }
