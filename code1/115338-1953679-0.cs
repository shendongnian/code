    public interface IMyDisposableClass : IDisposable
    {
	    bool SomeOtherMethod();
    }
    public interface IMyDisposableFactory
    {
	    IMyDisposableClass CreateClass();
    }
    public class Test
    {
	    IMyDisposableFactory _myDisposableFactory;
	    public Test(IMyDisposableFactory myDisposableFactory)
	    {
		    _myDisposableFactory = myDisposableFactory;
	    }
	    public bool Foo()
	    {
		    using (IMyDisposableClass client = _myDisposableFactory.CreateClass())
		    {
			    return client.SomeOtherMethod();
		    }
	    }
    }
