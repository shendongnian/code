    using (SqlDataReader reader = selectAttachment.ExecuteReader())
    {
        // only reading one anyway; doesn't need to be a 'while'.
        if (!reader.Read())
            return new byte[0];
        if (reader[0] == System.DBNull.Value)
            return new byte[0];
        byte[] data = (byte[])reader[0];
        if (data.Length == 0)
            return new byte[0];
        String base64String
        if (data.Length > 1 && data[1] == 00)
            base64String = Encoding.Unicode.GetString(data);
        else
            base64String = Encoding.ASCII.GetString(data);
        // Cuts off the GUID, and takes care of any trailing 00 bytes.
        String truncatedString = base64String.Substring(38).TrimEnd('\0');
        return Convert.FromBase64String(truncatedString);
    }
