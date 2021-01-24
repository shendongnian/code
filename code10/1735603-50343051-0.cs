    class Program
    {
        static void Main(string[] args)
        {
            var root = JsonConvert.DeserializeObject<Root>(File.ReadAllText("file.json"));
        }
    }
    public class Root
    {
        public List<FilterMatrix> Features { get; set; }
    }
    public class FilterMatrix
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
    }
