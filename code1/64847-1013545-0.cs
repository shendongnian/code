    [ComVisible( true )]
    [ClassInterface( ClassInterfaceType.None )]
    [Guid( "00000000-0000-0000-0000-000000000000" )]
    [ComDefaultInterface( typeof( IExposedClass ) )]
    public class ExposedClass : IExposedClass
    {
        //need a parameterless constructor - could use the default
        public ExposedClass() { }
    
        public string GetThing()
        {
            return "blah";
        }
    }
    
    [ComVisible( true )]
    [Guid( "00000000-0000-0000-0000-000000000000" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    public interface IExposedClass
    {
        string GetThing();
    }
