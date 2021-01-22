    public class CustomComboBox : ComboBox
    {
        public CustomComboBox()
        {
            base.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
        [DefaultValue(ComboBoxStyle.DropDownList)]
        public new ComboBoxStyle DropDownStyle
        {
            set { base.DropDownStyle = value; Invalidate(); }
            get { return base.DropDownStyle;}
        }
    }
