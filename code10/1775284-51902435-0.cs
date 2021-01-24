    try
    {
        float.TryParse(textBox1.Text, out float value);
        var product = new Product()
        {
            ProductPrice = value
        }
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
