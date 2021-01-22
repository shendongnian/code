    public static class ObjectExtensions
    {
        private static readonly MethodInfo CloneMethod = typeof(Object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);
    
        public static Object DeepClone(this Object originalObject)
        {
            if (originalObject == null) return null;
            var originalObjectType = originalObject.GetType();
            if (originalObjectType == typeof(String) | originalObjectType.IsValueType) return originalObject;
            var cloneObject = CloneMethod.Invoke(originalObject, null);
            foreach (FieldInfo fieldInfo in originalObjectType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy))
            {
                if (fieldInfo.FieldType.IsValueType) continue;
                var originalFieldValue = fieldInfo.GetValue(originalObject);
                var clonedFieldValue = originalFieldValue == null ? null : originalFieldValue.DeepClone();
                fieldInfo.SetValue(cloneObject, clonedFieldValue);
                if (clonedFieldValue == null) continue;
                if (fieldInfo.FieldType.IsArray)
                {
                    var arrayType = fieldInfo.FieldType.GetElementType();
                    if (arrayType.IsValueType | arrayType == typeof(String)) continue;
                    Object[] clonedArray = (Object[])clonedFieldValue;
                    for (long i = 0; i < clonedArray.LongLength; i++) clonedArray[i] = DeepClone(clonedArray[i]);
                }
            }
            return cloneObject;
        }
    }
