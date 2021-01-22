    class NoneBlockingDialog
    {
        Form dialog;
        Form Owner;
        public NoneBlockingDialog(Form f)
        {
            this.dialog = f;
            this.dialog.FormClosing += new FormClosingEventHandler(f_FormClosing);
        }
        void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(! e.Cancel)
                PUtils.SetNativeEnabled(this.Owner.Handle, true);
        }
        public void ShowDialogNoneBlock(Form owner)
        {
            this.Owner = owner;
            PUtils.SetNativeEnabled(owner.Handle, false);
            this.dialog.Show(owner);
        }
    }
    partial class PUtils
    {
                const int GWL_STYLE = -16;
        const int WS_DISABLED = 0x08000000;
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        static public void SetNativeEnabled(IntPtr hWnd, bool enabled)
        {
            SetWindowLong(hWnd, GWL_STYLE, GetWindowLong(hWnd, GWL_STYLE) & ~WS_DISABLED | (enabled ? 0 : WS_DISABLED));
        }
    }
