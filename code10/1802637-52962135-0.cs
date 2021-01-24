    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@"Your path to json file");
            JObject jObject = JObject.Parse(json);
            var fieldArray = jObject["Index"]["Fields"]["Field"].ToObject<List<NameValuePair>>();
            string value = fieldArray.Where(x => x.Name == "invItemID").Select(x => x.Value).FirstOrDefault();
            Console.WriteLine("Value: " + value);
            Console.ReadLine();
        }
    }
    class NameValuePair
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
   
