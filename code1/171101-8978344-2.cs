    public static T Deserialize<T>(string FilePath) where T : class
    {
    	try
    	{
    		XmlSerializer xml = new XmlSerializer(typeof(T));
    		FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
    		XmlSerializer xml = new XmlSerializer(typeof(T));
                    T res = (T)xml.Deserialize(fs);
    		fs.Close();
    		return res;
    	}
    	catch (Exception ex)
    	{
    		Debug.WriteLine("Failed to deserialize object of type " + typeof(T).FullName + ": " + ex.Message);
    		return default(T);
    	}
    }
