        public static Object Copy(this Object originalObject)
        {
            return InternalCopy(originalObject, new Dictionary<Object, Object>(new ReferenceEqualityComparer()));
        }
        private static Object InternalCopy(Object originalObject, IDictionary<Object, Object> visited)
        {
            if (originalObject == null) return null;
            var originalObjectType = originalObject.GetType();
            if (IsPrimitive(originalObjectType)) return originalObject;
            if (visited.ContainsKey(originalObject)) return visited[originalObject];
            var cloneObject = CloneMethod.Invoke(originalObject, null);
            visited.Add(originalObject, cloneObject);
            foreach (FieldInfo fieldInfo in originalObjectType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy))
            {
                if (IsPrimitive(fieldInfo.FieldType)) continue;
                var originalFieldValue = fieldInfo.GetValue(originalObject);
                var clonedFieldValue = originalFieldValue == null ? null : InternalCopy(originalFieldValue, visited);
                fieldInfo.SetValue(cloneObject, clonedFieldValue);
                if (clonedFieldValue == null) continue;
                if (fieldInfo.FieldType.IsArray)
                {
                    var arrayType = fieldInfo.FieldType.GetElementType();
                    if (IsPrimitive(arrayType)) continue;
                    Array clonedArray = (Array)clonedFieldValue;
                    for (long i = 0; i < clonedArray.LongLength; i++) clonedArray.SetValue(InternalCopy(clonedArray.GetValue(i), visited), i);
                }
            }
            return cloneObject;
        }
