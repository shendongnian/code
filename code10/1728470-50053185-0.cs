    using System;
    using System.Windows.Forms;
    namespace Sancarn {
        public class Form1 : Form {
            public event EventHandler MessageHandler;
            public Message lastMessage;
        
            public string ptrToString(System.IntPtr ptr) {
                return Marshal.PtrToStringAnsi(ptr);
            }
        
            [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            protected override void WndProc(ref Message m) {
                EventHandler handler = MessageHandler;
                lastMessage = m;
                if (null != MessageHandler) MessageHandler(this, EventArgs.Empty);
                base.WndProc(ref m);
            }
        }
    }
