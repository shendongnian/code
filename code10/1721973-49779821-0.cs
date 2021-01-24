    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(comboBox1.SelectedItem == "Yellow")
        {
             chart.Series["series1"].Points[0].Color = Color.Yellow;
        }
        else if(comboBox1.SelectedItem == "Red")
       {
             chart.Series["series1"].Points[0].Color = Color.Red;
       }
    }
