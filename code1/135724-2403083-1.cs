    [DllImport("MyDll.dll", 
        CallingConvention = CallingConvention.Winapi, 
        CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool GetTable(out IntPtr arrayPtr, out int size);
    
    public static List<TableEntry> GetTable() {
      var arrayValue = IntPtr.Zero;
      var size = 0;
      var list = new List<TableEntry>();
    
      if ( !GetTable(out arrayValue, out size)) {
        return list; 
      }
     
      var tableEntrySize = Marshal.SizeOf(typeof(TableEntry));
      for ( var i = 0; i < size; i++) {  
        var cur = (TableEntry)Marshal.PtrToStructure(arrayValue, typeof(TableEntry));
        list.Add(cur);
        arrayValue = new IntPtr(arrayValue.ToInt32() + tableEntrySize);
      }
      return list;
    }
     
