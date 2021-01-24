    public class DispatcherPriorityShim : Shim<
    #if NETFULL
		DispatcherPriority
    #elif NETCORE
		string
    #endif
	>
	{
	    public DispatcherPriorityShim(string it)
    #if NETFULL
			: base((DispatcherPriority)Enum.Parse(typeof(DispatcherPriority), it))
    #elif NETCORE
			: base(it)
    #endif
		{ }
	}
