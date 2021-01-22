    public class DisabledPasteWebBrowser : AxWebBrowser
    {
        const int WM_KEYDOWN = 0x100;
        const int CTRL_WPARAM = 0x11;
        const int VKEY_WPARAM = 0x56;
        Message prevMsg;
        public override bool PreProcessMessage(ref Message msg)
        {
            if (prevMsg.Msg == WM_KEYDOWN && prevMsg.WParam == new IntPtr(CTRL_WPARAM) && msg.Msg == WM_KEYDOWN && msg.WParam == new IntPtr(VKEY_WPARAM))
            {
                // Do not let this Control process Ctrl-V, we'll do it manually.
                HtmlEditorControl parentControl = this.Parent as HtmlEditorControl;
                if (parentControl != null)
                {
                    parentControl.ExecuteCommandDocument("Paste");
                }
                return true;
            }
            prevMsg = msg;
            return base.PreProcessMessage(ref msg);
        }
    }
