    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace LicenseManager {
    
      public static class WinApi {
    
        [DllImport( "user32.dll" )]
        static extern bool SetWindowPos( IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags );
    
        static private IntPtr HWND_TOPMOST = new IntPtr( -1 );
        
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
    
        static public void MakeTopMost( Form f ) {
          SetWindowPos( f.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE );
        }
    
      }
    }
