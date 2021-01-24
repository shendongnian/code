    class Program
    {
        public static void Main(string[] args)
        {
            var s = new StringBuilder();
            s.Append("Id,Name\r\n");
            s.Append("1,one\r\n");
            s.Append("2,two\r\n");
            using (var reader = new StringReader(s.ToString()))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.RegisterClassMap<TestMap>();
                csv.GetRecords<Test>().ToList();
            }
        }
    }
    public abstract class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Extra { get; set; }
    }
    public class Test1 : Test
    {
        //other Propertys
    }
    public class Test2 : Test
    {
        //other propertys
    }
    public class TestMap<T> : CsvClassMap<T> where T : Test
    {
        public TestMap()
        {
            AutoMap();
            if (typeof(T) == typeof(Test))
            {
                Map(m => m.Extra).Ignore();
            }
        }
    }
