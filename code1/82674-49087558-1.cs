    public interface IIntToByte
    {
    	Int32 Int { get; set;}
    
    	byte B0 { get; }
    	byte B1 { get; }
    	byte B2 { get; }
    	byte B3 { get; }
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct IntToByteLE : UserQuery.IIntToByte
    {
    	[FieldOffset(0)]
    	public Int32 IntVal;
    
    	[FieldOffset(0)]
    	public byte b0;
    	[FieldOffset(1)]
    	public byte b1;
    	[FieldOffset(2)]
    	public byte b2;
    	[FieldOffset(3)]
    	public byte b3;
    
    	public Int32 Int {
    		get{ return IntVal; }
    		set{ IntVal = value;}
    	}
    	
    	public byte B0 => b0;
    	public byte B1 => b0;
    	public byte B2 => b0;
    	public byte B3 => b0; 
    }
