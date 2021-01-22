    public static TextBox textBox2; // class atribute
    
    public Form2(TextBox textBoxForReturnValue)
    {
        textBox2= textBoxForReturnValue;
    }
    
    private void btnClose_Click(object sender, EventArgs e)
    {
    
        textBox2.Text = dataGridView1.CurrentCell.Value.ToString().Trim();
        this.Close();
    }
