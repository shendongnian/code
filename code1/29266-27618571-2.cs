    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    
        double parsedValue;
    
        if (!double.TryParse(textBox1.Text, out parsedValue))
        {
            textBox1.Text = "";
        }
    }
