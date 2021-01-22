    [DataContract]
    public class MyItem
    {
        [DataMember]
        public string Name { get; set; }
    
        [DataMember]
        public string Description { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var graph = new List<MyItem>
            {
                new MyItem { Name = "one", Description = "desc1" },
                new MyItem { Name = "two", Description = "desc2" }
            };
            var serializer = new DataContractJsonSerializer(graph.GetType());
            serializer.WriteObject(Console.OpenStandardOutput(), graph);
        }
    }
