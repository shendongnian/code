    public class CustomComboBox : ComboBox
    {
        private const int WM_SIZE = 0x0005;
    
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
    
            // A fix for ComboBoxStyle.DropDown mode.
            if (DropDownStyle == ComboBoxStyle.DropDown
                && (m.Msg & WM_SIZE) == WM_SIZE)
            {
                Select(0, 0);
            }
        }
    }
