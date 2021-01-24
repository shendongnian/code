    public static T MyGenericMethod<T>(string strEventData) where T : class
    {
        JObject jobject = JObject.Parse(strEventData);
        T result = jobject.SelectToken("ChangeSet").ToObject<T>();
        return result;
    }
    
