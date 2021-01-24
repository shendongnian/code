    private void button1_Click(object sender, EventArgs e)
    {
        System.Drawing.SolidBrush myBrush = new 
        System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;
        formGraphics = this.CreateGraphics();
        formGraphics.FillEllipse(myBrush, new Rectangle(200, 200, 30, 30));
        myBrush.Dispose();
        formGraphics.Dispose();
    }
