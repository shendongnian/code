    int number1, number2, number3, number4;
    if (Int32.TryParse(textBox1.Text, out number1) && Int32.TryParse(textBox2.Text, out number2) &&
        Int32.TryParse(textBox3.Text, out number3) && Int32.TryParse(textBox4.Text, out number4))
    {
        if(number1 + number2 + number3 + number4 == 100)
            MessageBox.Show("Activated");
        else
            MessageBox.Show("License key is not valid.", "License key is not valid.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
    }
    else
        MessageBox.Show("No letters allowed in the textboxes.", "No letters allowed in the textboxes", MessageBoxButtons.OK, MessageBoxIcon.Stop);
