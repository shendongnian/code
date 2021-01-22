    public static T DeepCopy<T>(this T value)
    {
        string json = JsonConvert.SerializeObject(value);
        return JsonConvert.DeserializeObject<T>(json);
    }
