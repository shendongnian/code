    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
        DateTime date;
        if (!DateTime.TryParseExact(textBox1.Text, 
            "dd-MM-yyyy", 
            CultureInfo.CurrentCulture, 
            DateTimeStyles.None, 
            out date))
        {
            MessageBox.Show(textBox1.Text + " is not a valid date");
            textBox1.Focus();
            e.Cancel = true;
            return;
        }
        if ((date < (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue) ||
            (date > (DateTime) System.Data.SqlTypes.SqlDateTime.MaxValue))
        {
            MessageBox.Show(textBox1.Text + " is out of range");
            textBox1.Focus();
            e.Cancel = true;
            return;
        }
    }
