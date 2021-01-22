    private void button1_Click(object sender, EventArgs e)
    {
        PictureBox pb = new PictureBox();
        pb.Location = new Point(0, 0);
        pb.Size = new Size(300, 300);
        pb.Image = SomeImage;
        pb.Click += new EventHandler(PictureBoxClick);
        Panel panel = new Panel();
        panel.Location = new Point(10, 40);
        panel.Size = new Size(300, 300);
        panel.Controls.Add(pb);
        flowLayoutPanel1.Controls.Add(panel);
    }
    private void PictureBoxClick(object sender, EventArgs e)
    {
        MessageBox.Show("Picture box clicked");
    }
