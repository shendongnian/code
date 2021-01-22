    [StructLayout(LayoutKind.Explicit)]
    public struct Foo
    {
    	[FieldOffset(0)]
    	public byte padding;
    	[FieldOffset(1)]
    	public string ValidReference;
    }
    
    public static void RunSnippet()
    {
    	Foo foo;
    	foo.padding = 0;
    	foo.ValidReference = "blah";
    }
