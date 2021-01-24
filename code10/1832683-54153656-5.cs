    using System;
    using Newtonsoft.Json;
    public class Test
    {
        public bool f1;
        public bool f2;
        public Test()
        {
            f1 = false;
            f2 = true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var json = JsonConvert.SerializeObject(new Test());
            Console.WriteLine(json);
        }
    }
