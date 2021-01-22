    public partial class CustomerMgmtForm : Form {
        // Assuming the design already done, so the TabControl control exists on your form.
        public CustomerMgmtForm() {
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
        }
        private void tabControl1_SelectedIndexchanged(object sender, EventArgs e) {
            switch((sender as TabControl).SelectedIndex) {
                case 0:
                    // Do nothing here (let's suppose that TabPage index 0 is the address information which is already loaded.
                    break;
                case 1:
                    // Let's suppose TabPage index 1 is the one for the transactions.
                    // Assuming you have put a DataGridView control so that the transactions can be listed.
                    // currentCustomer.Id can be obtained through the CurrencyManager of your BindingSource object used to data bind your data to your Windows form controls.
                    dataGridview1.DataSource = GetTransactions(currentCustomer.Id);
                    break;
            }
        }
    }
