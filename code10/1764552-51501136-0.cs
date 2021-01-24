    public sealed class MyClassMap : ClassMap<MyClass>
    {
        public MyClassMap()
        {
            AutoMap();
            Map( m => m.CreatedDate ).Ignore();
        }
    }
