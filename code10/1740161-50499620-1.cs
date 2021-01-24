    private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
    {
        if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
        {
            textBox2.Clear();
            return;
        }
        textBox2.Text = "Chosen colors are :";
        if (checkBox1.Checked)
            textBox2.Text += " color1";
        if (checkBox2.Checked)
            textBox2.Text += " color2";
        if (checkBox3.Checked)
            textBox2.Text += " color3";
    }
