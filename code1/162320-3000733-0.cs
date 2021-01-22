    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class MyComboBox : ComboBox {
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            SetWindowTheme(this.Handle, "", "");
        }
        [DllImport("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);
    }
