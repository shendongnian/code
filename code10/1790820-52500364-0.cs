    class Program
    {
        static void Main(string[] args)
        {
            string json1 = @"[{'Id1':'1','Name1':'Mike','Age1':43},{'Id1':'2','Name1':'Anna','Age1':56}]";
            string json2 = @"[{'Id2':'1','Name2':'Mike','Age2':43},{'Id2':'2','Name2':'Anna','Age2':56}]";
            //Pass json1 and deserialize into list of Sample1
            var sample1List = DeserializeList<Sample1>(json1);
            sample1List.ForEach(x => Console.WriteLine($"Id1: {x.Id1},  Name1: {x.Name1}, Age1: {x.Age1}"));
            Console.WriteLine("\n");
            //Pass json2 and deserialize into list of Sample2
            var sample2List = DeserializeList<Sample2>(json2);
            sample2List.ForEach(x => Console.WriteLine($"Id2: {x.Id2},  Name2: {x.Name2}, Age2: {x.Age2}"));
            Console.ReadLine();
        }
        public static List<T> DeserializeList<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
    class Sample1
    {
        public string Id1 { get; set; }
        public string Name1 { get; set; }
        public int Age1 { get; set; }
    }
    class Sample2
    {
        public string Id2 { get; set; }
        public string Name2 { get; set; }
        public int Age2 { get; set; }
    }
