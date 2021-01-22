    static class ObjectComparator<T>
    {
        public static bool CompareProperties(T newObject, T oldObject)
        {
            if (Equals(newObject, oldObject))
            {
                return true;
            }
            PropertyInfo[] newProps = newObject.GetType().GetProperties();
            PropertyInfo[] oldProps = oldObject.GetType().GetProperties();
            if (newProps.Length != oldProps.Length)
            {
                return false;
            }
            foreach (PropertyInfo newProperty in newProps)
            {
                PropertyInfo oldProperty = oldProps.SingleOrDefault(pi => pi.Name == newProperty.Name);
                if (oldProperty == null)
                    return false;
                object newval = newProperty.GetValue(newObject, null);
                object oldval = oldProperty.GetValue(oldObject, null);
                if (!Equals(newval, oldval))
                    return false;
            }
            return true;
        }
    }
