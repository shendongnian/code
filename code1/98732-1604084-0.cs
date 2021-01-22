    [DllImport("Blarggg.dll", CallingConvention := CallingConvention.Cdecl)] 
    public static extern System.UInt16 ReadProperty( 
            /* [IN]  */ System.Byte[] message, 
            /* [IN]  */ System.UInt16 length, 
            /* [OUT] */ out System.Byte invokeID );  
     
     
    private void DoIt()  
    { 
        System.Byte[] message = new System.Byte[2000]; 
        System.Byte InvokeID; 
        System.UInt16 ret = ReadProperty( message, 2000, out InvokeID );
    } 
