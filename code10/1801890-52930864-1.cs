    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{'Question': 'How \n can we serve \t you better? \n\n\t\t\n\t',
                             'Answer': 'You should \n provide your \r best \n\n\r\r\t\n' }";
            JObject jObject = JObject.Parse(json);
            var sanitizedJson = SanitizeJSON(jObject);
            JObject result = JObject.Parse(sanitizedJson);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        static string SanitizeJSON(JObject input)
        {
            string replacement = Regex.Replace(input.ToString(), @"\\t|\\n|\\r", string.Empty);
            return replacement.ToString();
        }
    }
