    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
    System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
    if (textBox1.Text.Length > 0)
    {
    if (!rEMail.IsMatch(textBox1.Text))
    {
    MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    textBox1.SelectAll();
    e.Cancel = true;
    }
    }
    }
