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
                csv.Configuration.RegisterClassMap<TestMap<Test>>();
                csv.GetRecords<Test>().ToList();
            }
        }
    }
    public class Test : Test1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
    public Abstract class Test1 
    {
       public decimal Extra { get; set; }
    }
    public class Test2 : Test1
    {
        //other propertys
    }
    public class TestMap<T> : CsvClassMap<T> where T : Test1
    {
        public TestMap()
        {
            AutoMap();
           
                Map(m => m.Extra).Ignore();
           
        }
    }
