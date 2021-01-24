    class Program
    {
        static void Main(string[] args)
        {
            var json = "{\"total\":" + 1 + ",\"totalpages\":" + 10 + ",\"tags\":[{\"id\":384},{\"id\":385}]}";
            var result = json.FromJSON<TagsResponse>();
            Console.WriteLine("Hello World!" + result);
        }
    }
    public static class Helper
    {
        public static T FromJSON<T>(this string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return (T)serializer.ReadObject(ms);
            }
        }
    }
    [DataContract]
    public class TagsResponse
    {
        [DataMember(Name = "total")]
        public int Total { get; set; }
        [DataMember(Name = "totalpages")]
        public int TotalPages { get; set; }
        [DataMember(Name = "tags")]
        public List<Tag> Tags { get; set; }
    }
    [DataContract]
    public class Tag
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
