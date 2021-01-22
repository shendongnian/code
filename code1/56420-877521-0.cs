    private void groupBox1_Resize(object sender, EventArgs e)
    {
    
        groupBox1.SuspendLayout();
    
        int middle = groupBox1.Width / 2;
        listBox1.Location = new Point(7, 20);
        listBox2.Location = new Point(middle, 20);
    
        listBox1.Size = new Size(middle - 7, groupBox1.Height - 27);
        listBox2.Size = new Size(middle - 7, groupBox1.Height - 27);
    
        groupBox1.ResumeLayout();
    }
