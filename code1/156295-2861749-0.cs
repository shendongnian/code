    public static string SerializeObject(object o)
    {
        string result = "";
        if (o.GetType().IsSerializable)
        {
            BinaryFormatter f = new BinaryFormatter();
            using (MemoryStream str = new MemoryStream())
            {
                f.Serialize(str, o);
                result = Convert.ToBase64String(str.ToArray());
            }
        }
        return result;
    }
