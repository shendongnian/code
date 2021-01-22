    class Program
    {
        private class Data1
        {
            public int Code1 { get; set; }
            public string Value1 { get; set; }
        }
        private class Data2
        {
            public int Code2 { get; set; }
            public string Value2 { get; set; }
        }
        static void Main(string[] args)
        {
            var data1 = new[] { new Data1 { Code1 = 1, Value1 = "one" }, new Data1 { Code1 = 2, Value1 = "two" }, new Data1 { Code1 = 3, Value1 = "three" } };
            var data2 = new[] { new Data2 { Code2 = 101, Value2 = "aaa" }, new Data2 { Code2 = 102, Value2 = "bbb" }, new Data2 { Code2 = 103, Value2 = "ccc" } };
            var query1 = from d1 in data1 select new { code = d1.Code1, text = d1.Value1 };
            var query2 = from d2 in data2 select new { code = d2.Code2, text = d2.Value2 };
            var datasource = query1.Union(query2);
            foreach (var d in datasource)
            {
                Console.WriteLine(d);
            }
        }
    }
