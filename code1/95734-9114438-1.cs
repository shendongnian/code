        [System.Runtime.InteropServices.DllImport("user32.dll")]
    
        public static extern bool LockWindowUpdate(IntPtr hWndLock);
        
        internal void FillTB(TextBox tb, string mes) 
        {
           try
           {
              LockWindowUpdate(tb.Handle);
        
              // Do your thingies with TextBox tb
           }
           finally
           {
              LockWindowUpdate(IntPtr.Zero);
           }
        }
