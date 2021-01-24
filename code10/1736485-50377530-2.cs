    public class ComboBoxCell : DataGridViewComboBoxCell
    {
        private static string psDefaultValue;
        public ComboBoxCell()
            : base() { this.Value = psDefaultValue; }
        public void DefaultValue(string Value)
        {
            psDefaultValue = Value;
            this.Value = Value;
        }
        public override Type ValueType => typeof(String);
        public override object DefaultNewRowValue => psDefaultValue;
    }
