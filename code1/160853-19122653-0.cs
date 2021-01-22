    public static T Get<T>(XDocument xml, string descendant, T @default)
    {
        try
        {
            var converter = TypeDescriptor.GetConverter(typeof (T));
            if (converter != null)
            {
                return (T) converter.ConvertFromString(xml.Descendants(descendant).Single().Value);
            }
            return @default;
        }
        catch
        {
            return @default;
        }
    }
