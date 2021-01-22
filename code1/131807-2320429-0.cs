    public interface IFoo { }
    public class Foo : IFoo { }
    public class Foo2 : IFoo { }
    public interface IDummy
    {
    	IFoo Foo { get; set; }
    }
    public class Dummy : IDummy
    {
    	public IFoo Foo { get; set; }
    }
    public class Dummy2 : IDummy
    {
    	public IFoo Foo { get; set; }
    }
    
    [TestFixture]
    public class configuring_concrete_types
    {
    	[Test]
    	public void should_use_configured_setter()
    	{
    		var container = new Container(cfg =>
    		{
    			cfg.ForConcreteType<Dummy>().Configure.Setter<IFoo>().Is(new Foo());
    			cfg.ForConcreteType<Dummy2>().Configure.Setter<IFoo>().Is(new Foo2());
    		});
    
    		container.GetInstance<Dummy>().Foo.ShouldBeOfType<Foo>();
    		container.GetInstance<Dummy2>().Foo.ShouldBeOfType<Foo2>();
    	}
    }
