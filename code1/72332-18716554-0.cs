    public class ViewOnlyTextBox : System.Windows.Forms.TextBox {
        // constants for the message sending
        const int WM_SETFOCUS = 0x0007;
        const int WM_KILLFOCUS = 0x0008;
    
        protected override void WndProc(ref Message m) {
            if(m.Msg == WM_SETFOCUS) m.Msg = WM_KILLFOCUS;
    
            base.WndProc (ref m);
        }
    }
