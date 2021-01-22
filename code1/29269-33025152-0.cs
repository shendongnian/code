    private void txtFirstValue_MouseLeave(object sender, EventArgs e)
        {
	int num;
            bool isNum = int.TryParse(txtFirstValue.Text.Trim(), out num);
            if (!isNum && txtFirstValue.Text != String.Empty)
            {
                MessageBox.Show("The First Value You Entered Is Not a Number, Please Try Again", "Invalid Value Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstValue.Clear();
            }
	}
