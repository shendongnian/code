    public class DisabledPasteWebBrowser : AxWebBrowser
    {
        public override bool PreProcessMessage(ref Message msg)
        {
            if (msg.WParam == new IntPtr(0x56)) /* This seems to be the WParam for CtrlV */
            {
                // Do not let this Control process Ctrl-V, we'll do it manually.
                return false;
            }
            return base.PreProcessMessage(ref msg);
        }
    }
