    private void Form1_Load(object sender, EventArgs e)
    {
    	button1.BackColor = Color.Red;
    	button2.BackColor = Color.Green;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
    	Color c = button1.BackColor;
    	button1.BackColor = Color.FromArgb(Math.Max(c.A - 10, (byte)0), c.R, c.G, c.B);
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
    	Color c = button2.BackColor;
    	button2.BackColor = Color.FromArgb(Math.Max(c.A - 10, (byte)0), c.R, c.G, c.B);
    }
    
    public static Color SetTransparency(int a, Color color)
    {
    	return Color.FromArgb(a, color.R, color.G, color.B);
    }
