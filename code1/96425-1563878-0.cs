    class myform : Form
    {
        public myform()
        {
            RegisterHotKey(Handle, id, modifiers, mykey);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x312) // this is WM_HOTKEY
            {
                Show();
            }
            base.WndProc(ref m);
        }
    }
