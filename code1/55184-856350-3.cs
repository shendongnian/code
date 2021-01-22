    // this goes to you init routine
    textBox1.Validating += textBox1_Validating;
    // the validation method
    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
        if (textBox1.Text.Length > 0)
        {
            int result;
            if (int.TryParse(textBox1.Text, out result))
            {
                // number is 0?
                e.Cancel = result == 0;
            }
            else
            {
                // not a number at all
                e.Cancel = true;
            }
        }
    }
