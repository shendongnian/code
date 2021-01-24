    if (((comboBox3.SelectedText == "Leave") || 
         comboBox3.SelectedText == "Holiday")) && 
         textBox2.Text == "0" && 
         textBox3.Text == "0" && 
         textBox4.Text == "0" && 
         textBox5.Text == "0" && 
         textBox6.Text == "0" && 
         textBox7.Text == "0" && 
         textBox10.Text == "0")
    {
        MessageBox.Show("Success");
    }
    else
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("State");
        sb.AppendLine(comboBox3.SelectedText);
        sb.AppendLine(textBox2.Text);
        sb.AppendLine(textBox3.Text);
        sb.AppendLine(textBox4.Text);
        sb.AppendLine(textBox5.Text);
        sb.AppendLine(textBox6.Text);
        sb.AppendLine(textBox7.Text);
        sb.AppendLine(textBox10.Text);
        Console.WriteLine(sb.ToString());
        MessageBox.Show(sb.ToString());
    }
