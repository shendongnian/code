    public class CustomComboBox : ComboBox
    {
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (DropDownStyle == ComboBoxStyle.DropDown)
            {
                Select(0, 0);
            }
        }
    }
