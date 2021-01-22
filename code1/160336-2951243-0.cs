    private void xGameForm_FormClosing(object sender, FormClosingEventArgs e) {
        if (DialogResult.No == MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            e.Cancel = true;
    }
    private void button1_Clink(object sender, EventArgs e) {
        Close();
    }
