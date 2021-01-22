    [StructLayout(LayoutKind.Explicit)]
    public struct Foo
    {
    	[FieldOffset(0)]
    	public byte padding;
    	[FieldOffset(1)]
    	public string InvalidReference;
    }
    
    public static void RunSnippet()
    {
    	Foo foo;
    	foo.padding = 0;
    	foo.ValidReference = "blah";
        // Console.WriteLine(foo); // uncommeting this line triggers the exception
    }
