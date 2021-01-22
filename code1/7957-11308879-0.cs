    public static class ObjectExtensions
    {
        private static readonly MethodInfo cloneMethod = typeof(Object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);
    
        public static Object Clone(this Object objectToClone)
        {
            Type objectType = objectToClone.GetType();
            object clonedObject = cloneMethod.Invoke(objectToClone, null);
            foreach (FieldInfo fieldInfo in objectType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy))
            {
                if (fieldInfo.FieldType.IsValueType) continue;
                var fieldValue = fieldInfo.GetValue(objectToClone);
                if (fieldValue != null)
                {
                    var clonedFieldValue = fieldValue.Clone();
                    fieldInfo.SetValue(clonedObject, clonedFieldValue);
                }
            }
            return clonedObject;
        }
        public static T Clone<T>(this T objectToClone)
        {
            return (T)Clone((Object)objectToClone);
        }
    }
