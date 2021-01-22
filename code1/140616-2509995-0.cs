    public void Example() {
      ...
      RegisterHotKey(IntPtr.Zero, id, mod, vk);
    }
   
    [DllImportAttribute("user32.dll", EntryPoint="RegisterHotKey")]
    [return: MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
    public static extern bool RegisterHotKey(
      IntPtr hWnd, 
      int id, 
      uint fsModifiers, 
      uint vk);
