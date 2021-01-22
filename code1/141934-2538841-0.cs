    public partial class SecondaryForm {
        // Let's suppose you have put a TextBox control in design mode named txtCusomerName.
        public string CustomerName {
            set {
                this.txtCustomerName.Text = value.Trim();
            }
        }
    }
    public partial class MainForm {
        // Suppose you have a button to show a form with the customer name.
        private btnShowCustomerName_Click(object sender, EventArgs e) {
            SecondaryForm f
            f.CustomerName = "Acme inc,";
            f.ShowDialog();
        }
    }
