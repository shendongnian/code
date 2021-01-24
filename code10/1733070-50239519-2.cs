    private void textBox3_Validating(object sender, CancelEventArgs e)
    {
        int val = 0;
        bool res = Int32.TryParse(textBox3.Text, out val);
        if (res == true && val > -1 && val < 101)
        {
            // add record
            e.Cancel = false;
        }
        else
        {
            textBox3.Clear();
            e.Cancel = true;
            MessageBox.Show("Please input 0 to 100 only.");
        }
    }
