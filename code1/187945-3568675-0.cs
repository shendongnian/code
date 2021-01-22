    using System;
    using System.Windows.Forms;
    class MyDgv : DataGridView {
        public event EventHandler Increment;
        public event EventHandler Decrement;
    
        protected override void OnKeyDown(KeyEventArgs e) {
            bool used = false;
            if (this.EditingControl == null) {
                if (e.KeyData == Keys.Oemplus) {
                    if (Increment != null) { Increment(this, EventArgs.Empty); used = true; }
                }
                else if (e.KeyData == Keys.OemMinus) {
                    if (Decrement != null) { Decrement(this, EventArgs.Empty); used = true; }
                }
            }
            if (!used) base.OnKeyDown(e);
        }
    }
