    [Guid("39c16a44-d28a-4153-a2f9-08d70daa0e22"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface MyInterface
    {
        VARIANT getAttributeAsVARIANT([MarshalAs(UnmanagedType.BStr)] string strAttributeName);
    }
    
