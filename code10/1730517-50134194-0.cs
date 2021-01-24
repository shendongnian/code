    static void Main(string[] args)
    {
        // Example-data
        string jsonInput = "{ \"response\":{\"numFound\":4661,\"start\":0,\"maxScore\":6.3040514,\"docs\":[\"a\",\"b\"] } }";
        // deserialize the inputData to out class "RootObject"
        RootObject r = JsonConvert.DeserializeObject<RootObject>(jsonInput);
        // Let's see if we got something in our object:
        Console.WriteLine("NumFound: " + r.response.numFound);
        Console.WriteLine("Start: " + r.response.start);
        Console.WriteLine("MaxScrote: " + r.response.maxScore);
        Console.WriteLine("Docs: " + string.Join(", ", r.response.docs));
    }
    public class Response
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public double maxScore { get; set; }
        public List<string> docs { get; set; }
    }
    public class RootObject
    {
        public Response response { get; set; }
    }
