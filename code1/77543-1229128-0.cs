    string s;
    using (SqlConnection conn = new SqlConnection(""))
    {
        using (SqlCommand cmd = new SqlCommand("", conn))
        {
            s = (string) cmd.ExecuteScalar();
        }
    }
    using (StringReader sr = new StringReader(s))
    {
        using (XmlReader reader = XmlReader.Create(sr))
        {
            DataContractSerializer deserializer = 
               new DataContractSerializer(typeToDeserialize);
            return deserializer.ReadObject(reader);
        }
    }
