    public static string Serialize<T>(T obj)
    {
      string returnVal = "";
      try
      {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
        using (MemoryStream ms = new MemoryStream())
        {
          serializer.WriteObject(ms, obj);
          returnVal = Encoding.Default.GetString(ms.ToArray());
        }
      }
      catch (Exception /*exception*/)
      {
        returnVal = "";
        //log error
      }
      return returnVal;
    }
