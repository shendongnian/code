    public static T Coalesce<T>(this SqlDataReader reader, string property)
    {
        return reader.IsDBNull(reader.GetOrdinal(property))
                   ? default(T)
                   : (T) reader[property];
    }
