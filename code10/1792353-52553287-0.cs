    static class Program
    {
       static void Main()
       {
                var json = "{ \"Negative\": [ \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\" ], \"Non-Negative\": [ \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\", \"a.txt\", \"b.txt\" ] }";
                var classObject = JsonConvert.DeserializeObject<RootObject>(json);
        }
    }
    
    public class RootObject
    {
       public List<string> Negative { get; set; }
       [JsonProperty("Non-Negative")]
       public List<string> NonNegative { get; set; }
    }}
