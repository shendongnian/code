static class ObjectComparator<T> { 
    public static bool CompareProperties(T newObject, T oldObject) {
        if (object.Equals(newObject, oldObject)) {
            return true;
        }
        if (newObject.GetType().GetProperties().Length != oldObject.GetType().GetProperties().Length) { 
            return false; 
        } 
        else { 
            var oldProperties = oldObject.GetType().GetProperties(); 
            foreach (PropertyInfo newProperty in newObject.GetType().GetProperties()) { 
                try { 
                    PropertyInfo oldProperty = oldProperties.Single<PropertyInfo>(pi => pi.Name == newProperty.Name); 
                    if (!object.Equals(newProperty.GetValue(newObject, null), oldProperty.GetValue(oldObject, null))) { 
                        return false; 
                    } 
                } 
                catch { 
                    return false; 
                } 
            } 
            return true; 
        } 
    } 
}
