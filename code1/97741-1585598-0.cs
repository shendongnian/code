    using System;
    using System.Runtime.InteropServices;
    
    class MainApp
    {
    [DllImport("user32.dll", EntryPoint="MessageBox")]
    public static extern int MessageBox(int hWnd, String strMessage, String
    strCaption, uint uiType);
    
    public static void Main()
    {
    MessageBox( 0, "Hello, this is PInvoke in operation!", ".NET", 0 );
    }
    }
