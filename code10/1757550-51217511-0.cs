    private void button14_Click(object sender, EventArgs e)
    {
        if (checkBox1.Checked)
        {
            textBox1.Focus();
            SendKeys.Send("Q");
        }
        else
        {
            textBox1.Focus();
            SendKeys.Send("q");
        }
    }
