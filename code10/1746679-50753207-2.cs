    public class MyComboBox : ComboBox
    {
        NativeMwthods.ListBoxHelper listBoxHelper;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            var info = new NativeMwthods.COMBOBOXINFO();
            info.cbSize = Marshal.SizeOf(info);
            NativeMwthods.GetComboBoxInfo(this.Handle, ref info);
            listBoxHelper = new NativeMwthods.ListBoxHelper(info.hwndList);
        }
    }
