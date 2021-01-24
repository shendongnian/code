    double aantalgroep = 0;
    double number = 0;
    if (radioButton1.Checked)
    {
        if (double.TryParse(textBox1.Text, out aantalgroep))
        {
            // Stuff you do when successful.
            number = aantalgroep * 8;
            textBox2.Text = number.ToString();
        }
        else
        {
            // Stuff you do when unsuccessful.
            // Something like textBox2.Text = "0"; ?
        }
    }
