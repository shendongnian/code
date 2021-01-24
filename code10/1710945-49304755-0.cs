    using System.Collections.Generic;
    using Newtonsoft.Json;
    class Foo
    {
        // no clue what b+o look like from the question; modify to suit
        public int[] b { get; set; }
        public string[] o { get; set; }
    }
    static class P
    {
        static void Main()
        {
            var json = @"{""23521952"": {""b"": [], ""o"": []}, ""23521953"": {""b"": [], ""o"": []}}";
            var obj = JsonConvert.DeserializeObject<Dictionary<string, Foo>>(json);
            foreach(var pair in obj)
            {
                System.Console.WriteLine($"{pair.Key}, {pair.Value}");
            }
    
        }
    }
