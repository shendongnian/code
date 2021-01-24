    public class Bar
    {
    	// Optional c'tor if param(s) are required to be initialized for typical use
    
    	// Accessor for e
    	public MyEnum e
    	{
    		get
    		{
    			return m_BarInterop.e;
    		}
    		set
    		{
    			m_BarInterop.e = value;
    		}
    	}
    
    	// Accessor for s
    	public uint s
    	{
    		get
    		{
    			VerifyUIntPtrFitsInUint(m_BarInterop.s);   // will throw an exception if value out of range
    			return (uint)m_BarInterop.s;
    		}
    		set
    		{
    			// uint will always fit in UIntPtr
    			m_BarInterop.s = (UIntPtr)value;
    		}
    	}
    
    	// Interop-compatible 'Bar' structure (not required to be inner struct)
    	[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    	internal struct Bar_Interop
    	{
    		public MyEnum e;
    		public System.UIntPtr s;
    	}
    
    	// Instance of interop-compatible 'Bar' structure
    	internal Bar_Interop m_BarInterop;
    }
