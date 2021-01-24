    private void button1_Click(object sender, EventArgs e)
    {
        float temp;
        if (float.TryParse(textBox1.Text, out temp))
        {
            var product = new Product { ProductPrice = temp };
        }
        else
        {
            MessageBox.Show("Please enter a valid number and try again");
        }
    }
