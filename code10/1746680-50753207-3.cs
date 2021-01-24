    public class MyToolStripComboBox : ToolStripComboBox
    {
        public MyToolStripComboBox()
        {
            this.Control.HandleCreated += Control_HandleCreated;
        }
        NativeMwthods.ListBoxHelper listBoxHelper;
        private void Control_HandleCreated(object sender, EventArgs e)
        {
            var info = new NativeMwthods.COMBOBOXINFO();
            info.cbSize = Marshal.SizeOf(info);
            NativeMwthods.GetComboBoxInfo(this.Control.Handle, ref info);
            listBoxHelper = new NativeMwthods.ListBoxHelper(info.hwndList);
        }
    }
