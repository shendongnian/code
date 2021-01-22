    private bool TryParse<T>(XElement element, string attributeName,out T value)
    {
        if (element.Attribute(attributeName) != null && !string.IsNullOrEmpty(element.Attribute(attributeName).Value))
        {
            string valueString = element.Attribute(attributeName).Value;
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                value = (T)converter.ConvertFrom(valueString);
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }
        value = default(T);
        return false;
    }
