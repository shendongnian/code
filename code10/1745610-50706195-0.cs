    private void button1_Click(object sender, EventArgs e)
    {
        Form1 frm1 = new Form1();
        for (int i = 0; i < frm1.comboBox1.Items.Count; i++)
        {
            int Value = Convert.ToInt16(frm1.comboBox1.Items[i]);
            chart1.Series["Saved Results"].Points.AddXY(0, Value);
        }
    }
