    public static class GenericExtensions
    {
        public static string ToJsonString<T>(this T input)
        {
            string json;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(input.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                ser.WriteObject(ms, input);
                json = Encoding.Default.GetString(ms.ToArray());
            }
            return json;
        }
    }
