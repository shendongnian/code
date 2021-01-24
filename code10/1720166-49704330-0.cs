    PictureBox[] bossHealth = new PictureBox[20];
    for( int i = 0; i<19; i++)
    {
        bossHealth[i] = new PictureBox();
        bossHealth[i].Name = "health";
        bossHealth[i].Size = new Size(10, 26);
        bossHealth[i].BackColor = Color.LimeGreen;
        bossHealth[i].Location = new Point(this.Width / 2 + (i * 10), 12);
        Controls.Add(bossHealth[i]);
    }
