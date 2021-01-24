    namespace PortabilityLibrary.Shims
    {
	  public class $enumname$Shim : Shim<
    #if NETFULL
		$enumname$
    #elif NETCORE
		string
    #endif
	>
	  {
		    public $enumname$Shim(string it)
    #if NETFULL
		    : base(($enumname$)Enum.Parse(typeof($enumname$), it))
    #elif NETCORE
			  : base(it)
    #endif
		    { }
	  }
    }
