    // in one library
    public class Foo
    {
    internal string _bar = "some value";
    }
    
    // in another library
    public class FooModel
    {
    public string Bar { get; set; }
    }
    
    Mapper.CreateMap<Foo, FooModel>()
    .ForMember(x => x.Bar, o => o.ResolveUsing(new PrivateFieldResolver("_bar")));
