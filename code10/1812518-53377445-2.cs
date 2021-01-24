    class Program
    {
        //Here I'm loading in your json for testing.
        static string input = File.ReadAllText("Input.json");
        static void Main(string[] args)
        {
            Type genericResponseType = typeof(Response<>).MakeGenericType(new[] { typeof(Person) });
            var result = JsonConvert.DeserializeObject(input, genericResponseType);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
