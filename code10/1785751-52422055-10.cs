    namespace PortabilityLibrary.Shims
    {
	  public class $classname$Shim : Shim<
    #if NETFULL
		$classname$
    #elif NETCORE
		$classname$
    //NullObject
    #endif
	>
	  {
		    public $classname$Shim()
    #if NETFULL
		    : base(new $classname$())
    #elif NETCORE
			: base(new $classname$())
        //: base(new NullObject())
    #endif
		    {}
	  }
    }
