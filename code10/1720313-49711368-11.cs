    public class NameAndUri
    {
        public string url { get; set; }
        public string name { get; set; }
    }
   
    public class NameAndUri<T> : NameAndUri
	{
        public T Deserialize()
        {
            return JsonExtensions.DeserializeFromUri<T>(url);
        }
	}
    public static partial class JsonExtensions
    {
        public static T DeserializeAnonymousTypeFromUri<T>(string uri, T anonymousTypeObject)
        {
            return DeserializeFromUri<T>(uri);
        }
        public static T DeserializeFromUri<T>(string uri)
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return JsonSerializer.CreateDefault().Deserialize<T>(jsonReader);
            }
        }
    }
