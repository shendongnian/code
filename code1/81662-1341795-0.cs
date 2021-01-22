    [DllImport("CodeMethodsToString.dll")]
    [return: MarshalAs(UnmanagedType.BStr)]
    private static extern string CodeMethodsToString(IntPtr functionObject);
    public static void CodeMethodsToXML(XmlElement parent, CodeElements elements)
    {
       GCHandle pin;
       try
       {
          pin = GcHandle.Alloc(elements, GCHandleType.Pinned);
          string methods = CodeMethodsToString(pin.AddrOfPinnedObject());
        }
        finally
        {
           pin.Free();
        }
    }
