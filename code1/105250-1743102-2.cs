    void AddToArray(object array, int index) {
        if(array == null) {
            throw new ArgumentNullException();
        }
        Type arrayType = array.GetType();
        if(!arrayType.IsArray) {
            throw new InvalidOperationException("array must be an Array");
        }
        PropertyInfo lengthProperty = arrayType.GetProperty("Length");
        int length = (int)lengthProperty.GetValue(array, null);
        if (index < 0 || index >= length) {
            throw new ArgumentOutOfRangeException("index");
        }
        MethodInfo setValue = arrayType.GetMethod(
            "SetValue",
            new[] { typeof(object), typeof(int) }
        );
        object newInstance = Activator.CreateInstance(elementType);
        setValue.Invoke(array, new[] { newInstance, index });
    }
