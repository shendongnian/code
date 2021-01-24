    private void button1_Click(object sender, EventArgs e)
    {
        double column1 = 0; 
        double column2 = 0;
        double column3 = 0;
    
        double.TryParse(textBox1.Text,out column1);
        double.TryParse(textBox2.Text,out column2);
        double.TryParse(textBox3.Text,out column3);
    
        string[] results = {((column1 * 20)/100).ToString(), 
                            ((column2 * 60)/100).ToString(),
                            ((column3 * 20)/100).ToString()} ;
        
        textBox4.Text = string.Join(",",results);
    }
