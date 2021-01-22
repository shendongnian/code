    int[] verdierX = new int[8];
    private void Form1_Load(object sender, EventArgs e)
    {
        for (var i = 0; i < 8; i++)
        {
            TextBox tb = (TextBox)FindControl("box" + i.ToString());
            verdierX[i] = (int)decimal.Parse(tb.Text);
        }
    }
