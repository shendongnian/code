    InitializeComponent();
    pictureBox1.Controls.Add(pictureBox2);
    pictureBox2.Location = new Point(0, 0);
    pictureBox2.BackColor = Color.Transparent;
    pictureBox1.SendToBack();
    pictureBox2.BringToFront();
