    private void textBox1_Validating(object sender,
            System.ComponentModel.CancelEventArgs e) {
        if (!Microsoft.VisualBasic.Information.IsNumeric(textBox1.Text)) {
            e.Cancel = true;
        } else {
            // Do something here
        }
    }
