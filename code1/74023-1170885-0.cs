	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("01A31113-9353-44cc-A1F4-C6F1210E4B30")]  //Allocate your own GUID
	public interface _Test
	{
		string HelloWorld {get; };
	}
	
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("E2F07CD4-CE73-4102-B35D-119362624C47")]  //Allocate your own GUID
	[ProgId("TestDll.Test")]
	public class Test : _Test
	{
         public string HelloWorld { get { return "Hello, World! "; } }
        }
