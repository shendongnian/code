    public static string SafeGetString(this SqlDataReader reader, int colIndex)
    {
       if(!reader.IsDBNull(colIndex))
           return reader.GetString(colIndex);
       else 
           return string.Empty;
    }
