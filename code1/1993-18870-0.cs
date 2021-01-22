    #if CSharp
    namespace MyNamespace.SharedEnumerations
    {
    public
    #endif
    
    
    enum MyFirstEnumeration
    {
    	Autodetect = -1,
        Windows2000,
        WindowsXP,
        WindowsVista,
        OSX,
        Linux,
    	
    	// Count must be last entry - is used to determine number of items in the enum
    	Count
    };
    #if CSharp
    public 
    #endif
        
    enum MessageLevel
    {
        None,           // Message is ignored
        InfoMessage,    // Message is written to info port.
        InfoWarning,    // Message is written to info port and warning is issued
        Popup           // User is alerted to the message
    };
    
    #if CSharp
        public delegate void MessageEventHandler(MessageLevel level, string message);
    }
    #endif
