    internal sealed class MyCsvMap : ClassMap<Foo>
    {
        public MyCsvMap()
        {
            Map(x => x.Bar1).Name("Header 1");
            Map(x => x.Bar2).Name("Header 2");
            Map(x => x.Bar3).Name("Header 3");
            Map(x => x.Bar4).Name("Header 4");
            Map(x => x.Bar5).Name("Header5");
        }
    }
