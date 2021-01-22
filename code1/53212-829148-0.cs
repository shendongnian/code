    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new List<KeyValuePair<string, string>>
                                 {
                                     new KeyValuePair<string, string>("A", "AValue"),
                                     new KeyValuePair<string, string>("B", "BValue")
                                 };
            string output = "?" + string.Join("&", parameters.ConvertAll(param => param.ToQueryString()).ToArray());
        }
    }
    public static class KeyValueExtensions
    {
        public static string ToQueryString(this KeyValuePair<string, string> obj)
        {
            return obj.Key + "=" + HttpUtility.UrlEncode(obj.Value);
        }
    }
