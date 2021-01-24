    [StructLayout(LayoutKind.Explicit, Size = SIZE)]
    internal unsafe struct TestStruct
    {
    	public const int SIZE = 32;
    
    	[FieldOffset(0)]
    	public fixed byte _data[SIZE];
    
    	[FieldOffset(0), MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
    	private Guid guid1;
    
    	[FieldOffset(16), MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
    	private Guid guid2;
    
    	public Guid Guid1 { get => guid1; set => guid1 = value; }
    	public Guid Guid2 { get => guid2; set => guid2 = value; }
    }
