    [StructLayout (LayoutKind.Explicit)]
    struct FloatUnion
    {
    	[FieldOffset (0)]
    	public float value;
    
    	[FieldOffset (0)]
    	public int binary;
    }
    
    public static bool IsNaN (float f)
    {
    	FloatUnion union = new FloatUnion ();
    	union.value = f;
    
    	return ((union.binary & 0x7F800000) == 0x7F800000) && ((union.binary & 0x007FFFFF) != 0);
    }
