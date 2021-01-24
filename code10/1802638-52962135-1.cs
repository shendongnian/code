    class Program
    {
        static void Main(string[] args)
        {
            //Get your json from file
            string json = File.ReadAllText(@"Your path to json file");
            //Parse your json
            JObject jObject = JObject.Parse(json);
            //Get your "Field" array to List of NameValuePair
            var fieldArray = jObject["Index"]["Fields"]["Field"].ToObject<List<NameValuePair>>();
            //Retrieve Value for key "invItemID"
            string value = fieldArray.Where(x => x.Name == "invItemID").Select(x => x.Value).FirstOrDefault();
            //Print this value on console
            Console.WriteLine("Value: " + value);
            Console.ReadLine();
        }
    }
    class NameValuePair
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
   
