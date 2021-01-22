    class SmoothScrollIntercept : System.Windows.Forms.NativeWindow
    {
        public SmoothScrollIntercept(IntPtr hWnd)
        {
            // assign the handle and listen to this control's WndProc
            this.AssignHandle(hWnd);
        }
        protected override void WndProc(ref Message m)
        {
            // listen to WndProc here, do things
            if ((m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL)
                && (((int)m.WParam & 0xFFFF) == 5)) 
            {
                m.WParam = (IntPtr)(((int)m.WParam & ~0xFFFF) | 4);
            }
            base.WndProc(ref m);
        } 
    }
    // using this code:
    SmoothScrollIntercept intercept = new SmoothScrollIntercept(myControl.Handle);
    // myControl is now using smooth scrolling!
