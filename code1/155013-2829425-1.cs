    using System;
    using System.Windows.Forms;
    
    class MyTextBox : TextBox {
        protected override void OnKeyDown(KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                (this.Parent as ContainerControl).SelectNextControl(this, true, true, true, true);
                return;
            }
            base.OnKeyDown(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e) {
            if (e.KeyChar == '\r') e.Handled = true;
            base.OnKeyPress(e);
        }
    }
