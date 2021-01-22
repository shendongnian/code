    public class HexNumericUpDown : System.Windows.Forms.NumericUpDown
    {
        public HexNumericUpDown()
        {
            Hexadecimal = true;
        }
        protected override void ValidateEditText()
        {
            if (base.UserEdit)
            {
                base.ValidateEditText();
            }
        }
        protected override void UpdateEditText()
        {
            Text = System.Convert.ToInt64(base.Value).ToString("X" + HexLength);
        }
        [System.ComponentModel.DefaultValue(4)]
        public int HexLength
        {
            get { return m_nHexLength; }
            set { m_nHexLength = value; }
        }
        public new System.Int64 Value
        {
            get { return System.Convert.ToInt64(base.Value); }
            set { base.Value = System.Convert.ToDecimal(value); }
        }
        private int m_nHexLength = 4;
    }
