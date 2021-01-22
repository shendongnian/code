        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Really want to close?", "Closing"
                , MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
