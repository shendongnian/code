       [DllImport("ole32.dll", PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern object CoCreateInstance([In] ref Guid clsid,[MarshalAs(UnmanagedType.Interface)] object punkOuter,int context, [In] ref Guid iid);
          
    
    public object createComObject(){ 
        Guid IID_IUnknown = new Guid("{00000000-0000-0000-C000-000000000046}");
            
        var gid = "{6bf52a52-394a-11d3-b153-00c04f79faa6}"; //your ocx guid
        var clsid = new Guid(gid);
            
        object yourOCX = CoCreateInstance(ref clsid, (object)null, 1, ref IID_IUnknown);
      return yourOCX ;
    }
