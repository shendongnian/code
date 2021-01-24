    Is64BitProcess False
    Running As SMO01\bob
    Unhandled Exception: System.UnauthorizedAccessException: Retrieving the COM class factory for component with CLSID {0DC1F11A-A187-3B6D-9888-17E635DB0974} failed due to the following error: 80070005 Access is denied. (Exception from HRESULT: 0x80070005 (E_ACCESSDENIED)).
       at System.RuntimeTypeHandle.CreateInstance(RuntimeType type, Boolean publicOnly, Boolean noCheck, Boolean& canBeCached, RuntimeMethodHandleInternal& ctor, Boolean& bNeedSecurityCheck)
       at System.RuntimeType.CreateInstanceSlow(Boolean publicOnly, Boolean skipCheckThis, Boolean fillCache, StackCrawlMark& stackMark)
       at System.RuntimeType.CreateInstanceDefaultCtor(Boolean publicOnly, Boolean skipCheckThis, Boolean fillCache, StackCrawlMark& stackMark)
       at System.Activator.CreateInstance(Type type, Boolean nonPublic)
       at System.Activator.CreateInstance(Type type)
       at UserApp.Program.Main(String[] args) in C:\Users\simon\source\repos\TrustedSystem\UserApp\Program.cs:line 14
