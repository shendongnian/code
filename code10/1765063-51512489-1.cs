    public class MyClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    
    public sealed class MyClassMap : ClassMap<MyClass>
    {
        public MyClassMap()
        {
            AutoMap();
            Map( m => m.CreatedDate ).Ignore();
        }
    }
