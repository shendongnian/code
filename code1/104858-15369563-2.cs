        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dg;
            using (DialogCenteringService centeringService = new DialogCenteringService(this)) // center message box
            {
                dg = MessageBox.Show(this, "Are you sure?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (dg == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
