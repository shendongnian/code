    public class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            FlatStyle = FlatStyle.Popup;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0201 /* WM_LBUTTONDOWN */ || m.Msg == 0x0203 /* WM_LBUTTONDBLCLK */)
            {
                int x = m.LParam.ToInt32() & 0xFFFF;
                if (x >= Width - SystemInformation.VerticalScrollBarWidth)
                    base.WndProc(ref m);
                else
                {
                    Focus();
                    Invalidate();
                }
            }
            else
                base.WndProc(ref m);
        }
    }
