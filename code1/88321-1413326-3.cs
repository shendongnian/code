    public class FooMap : ClassMap<Foo>
    {
        public FooMap()
        {
            Id( x => x.Id).Access.Field ();
        }
    }
?
