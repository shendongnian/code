        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Program?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.FormClosing -= MainForm_FormClosing;
                Application.Exit();
            }
        }
