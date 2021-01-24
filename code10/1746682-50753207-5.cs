    public class MyComboBox : ComboBox
    {
        NativeMethods.ListBoxHelper listBoxHelper;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            var info = new NativeMethods.COMBOBOXINFO();
            info.cbSize = Marshal.SizeOf(info);
            NativeMethods.GetComboBoxInfo(this.Handle, ref info);
            listBoxHelper = new NativeMethods.ListBoxHelper(info.hwndList);
        }
    }
