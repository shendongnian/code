    using System.Windows.Forms;
    namespace MyNamespace {
        public class DataGridViewCheckboxCellFilter : DataGridViewCheckBoxCell {
            public DataGridViewCheckboxCellFilter() : base() {
                this.FalseValue = 0;
                this.TrueValue = 1;
                this.Value = TrueValue;
            }
        }
    }
