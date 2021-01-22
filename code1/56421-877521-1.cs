    private void groupBox1_Resize(object sender, EventArgs e)
    {
        groupBox1.SuspendLayout();
        
        listBox1.Location = new Point(7, 20);
        listBox2.Location = new Point(groupBox1.Width / 2, 20);
        
        listBox1.Size = new Size(groupBox1.Width / 2 - 6, groupBox1.Height - 27);
        listBox2.Size = new Size((groupBox1.Width + 1) / 2 - 6, groupBox1.Height - 27);
        
        groupBox1.ResumeLayout();
    }
