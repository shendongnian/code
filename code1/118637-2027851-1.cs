    public class FooMapping : ClassMap<Foo>
    {
        public FooMapping()
        {
            Not.LazyLoad();
            Id(c => c.Id).GeneratedBy.HiLo("1");
            Map(c => c.Name).Not.Nullable().Length(100);
            HasMany(x => x.Bars).Not.LazyLoad(); // <----------
        }
    }
