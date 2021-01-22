    [PluginFamily("Default")]
    public interface IAnotherObject
    {
        ...
    }
    
    [PluginFamily("Default")]
    public interface ICallingObject
    {
        ...
    }
    
    [Pluggable("Default")]
    public class AnotherObject : IAnotherObject
    {
        private IWidget _widget;
        public AnotherObject(IWidget widget)
        {
            _widget = widget;
        }
    
        public void SomeMethod()
        {
            //..do something with _widget
        }
    }
    
    [Pluggable("Default")]
    public class CallingObject : ICallingObject
    {
        public void AnotherMethod()
        {
            ObjectFactory.GetInstance<IAnotherObject>().SomeMethod();
        }
    }
