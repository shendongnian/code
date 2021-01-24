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
    }
    public class Test1 : Test
    {
        public decimal Extra { get; set; }
    }
    public class Test2 : Test
    {
        //some property you need.
        //for example
        public decimal ExtraTwo { get; set; }
    }
    public class TestMap<T> : CsvClassMap<T> where T : Test
    {
        public TestMap()
        {
            AutoMap();
            if (typeof(T) == typeof(Test1))
            {
                Map(m => m.Extra).Ignore();
            }
            if(typeof(T) == typeof(Test2))
            {
                Map(m => m.ExtraTwo).Ignore();
            }
        }
    }
