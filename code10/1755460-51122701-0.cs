    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"Errors\": {\"NoCountry\": {\"MSG\": \"The CountryCode field is required.\",\"Description\": \"Error encountered when Country parameter is missing from the request\"},\"NoLOI\": {\"MSG\": \"Validation failed: \r\n -- LengthOfInterview cannot be empty\", \"Description\": \"Error encountered when LOI parameter is missing from the request\"},}}";
            var Json = JsonConvert.DeserializeObject<ErrorsClass>(json);
            var obj = JsonConvert.DeserializeObject<Dictionary<string, ErrorsDictionary>>(Json.Errors.ToString());
            foreach (var f in obj)
            {
                Console.WriteLine("Nume={0} Mesaj={1} Description={2}", f.Key, f.Value.MSG, f.Value.Description);
            }
            Console.Read();
        }
    }
    public class ErrorsDictionary
    {
        public string MSG { get; set; }
        public string Description { get; set; }
    }
    public class DicRoot
    {
        public Dictionary<string, ErrorsDictionary> ErrorsDic { set; get; }
    }
    class ErrorsClass
    {
        public object Errors { get; set; }
    }
