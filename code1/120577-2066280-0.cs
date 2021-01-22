    public struct ObjectInfo
    {
    	public int numObjects;
    	[MarshalAs(UnmanagedType.LPArray, SizeConst = 1)]
    	public ObjectType[] objListPointer;
    }
