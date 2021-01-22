        private void WriteCheck_Shown(object sender, EventArgs e)
        {
            Visible = false;
            SelectBankAccountDialog sbad = new SelectBankAccountDialog();
            DialogResult result = sbad.ShowDialog();
            if (result == DialogResult.Cancel) {
                this.Close();
            } else {
                MessageBox.Show(result.ToString());
            }
            MessageBox.Show(sbad.bankaccountID.ToString());
            Visible = true;
        }
