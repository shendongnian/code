    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        // Check if the text box can be parsed as an int and only
        // update the elipse if it is valid
        int getal1 = 0;
        if (int.TryParse(textBox1.Text, out getal1))
        {
            Graphics tknn1 = panel1.CreateGraphics();
            e.Graphics.FillEllipse(Brushes.Red, 0, 0, getal1, getal1);
        }
    }
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        panel1.Invalidate();
    }
