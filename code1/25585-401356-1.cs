    public static string GenerateJsonString(object o) 
    {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(o.GetType());
        using (MemoryStream ms = new MemoryStream())
        {
            ser.WriteObject(ms, o);
            json = Encoding.Default.GetString(ms.ToArray());
            ms.Close();
            return json;
        }
    }
