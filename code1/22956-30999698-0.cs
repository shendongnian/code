    public static class Dumper
    {
        public static void Dump(this object obj)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj)); // your logger
        }
    }
