    public class MyToolStripComboBox : ToolStripComboBox
    {
        public MyToolStripComboBox()
        {
            this.Control.HandleCreated += Control_HandleCreated;
        }
        NativeMethods.ListBoxHelper listBoxHelper;
        private void Control_HandleCreated(object sender, EventArgs e)
        {
            base.OnVisibleChanged(e);
            var info = new NativeMethods.COMBOBOXINFO();
            info.cbSize = Marshal.SizeOf(info);
            NativeMethods.GetComboBoxInfo(this.Control.Handle, ref info);
            listBoxHelper = new NativeMethods.ListBoxHelper(info.hwndList);
        }
    }
