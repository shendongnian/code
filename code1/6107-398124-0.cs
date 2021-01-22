        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                errorProvider1.SetError(sender as Control, "Can not be empty");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(sender as Control, "");
            }
        }
