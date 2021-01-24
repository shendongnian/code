        class MyClass
        {
            public void Test()
            {
                var x = @"{'Resource' : ['1', '2']}";
                var r = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(x);
            }
        }
        public static void Main(string[] args)
        {
            var l = new MyClass();
            l.Test();
        }
