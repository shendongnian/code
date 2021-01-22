    using System;
    using System.Windows.Forms;
    
    class MyBrowser : WebBrowser {
        protected override void WndProc(ref Message m) {
            if (m.Msg >= 0x200 && m.Msg <= 0x20a) {
                // Handle mouse messages
                //...
            }
            else base.WndProc(ref m);
        }
    }
