    public class MouseActivateListener : NativeWindow
    {
        private Control parent;
        public MouseActivateListener(Control parent)
        {
            parent.HandleCreated += this.OnHandleCreated;
            parent.HandleDestroyed += this.OnHandleDestroyed;
            parent.Leave += Parent_Leave;
            this.parent = parent;
            if (parent.IsHandleCreated)
            {
                AssignHandle(parent.Handle);
            }
        }
        private void Parent_Leave(object sender, EventArgs e)
        {
            MouseActivated = false;
        }
        private void OnHandleCreated(object sender, EventArgs e)
        {
            AssignHandle(((Form)sender).Handle);
        }
        private void OnHandleDestroyed(object sender, EventArgs e)
        {
            ReleaseHandle();
        }
        public bool MouseActivated { get; set; }
        [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            const Int32 WM_MouseActivate = 0x21;
            base.WndProc(ref m);
          
            if (m.Msg == WM_MouseActivate && m.Result.ToInt32() < 3)
            {
                MouseActivated = true;
            }
        }
    }
