    int _position = 10;
    private void spawn_Click(object sender, EventArgs e)
    {
        var pictureTest = new PictureBox();
        pictureTest.Image = Properties.Resources.testimage;
        pictureTest.Location = new Point(_position, 250);
        pictureTest.Name = "spawn1";
        pictureTest.Size = new Size(50, 50);
        pictureTest.TabIndex = 98;
        pictureTest.TabStop = false;
        this.Controls.Add(pictureTest);
        _position += 100;
    }
