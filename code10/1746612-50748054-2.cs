    private void button1_Click(object sender, EventArgs e)
    {
        double aantalgroep;
        if (!double.TryParse(textBox1.Text, out aantalgroep))        
        {
            textBox1.Text = "0";
        }
        else 
        {
            double kw = Math.Pow(aantalgroep, 2);
            textBox1.Text = String.Format("Kwadraat van {0} is: {1}", aantalgroep, kw);
        }
    }
