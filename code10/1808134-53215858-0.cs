    ...
    foreach (var pict in this.Controls.OfType<PictureBox>())
    {
        // pict is now a Picturebox, you can access all its properties as you have constructed it
        // the name was constructed that way: Name = "pictureBox" + obstacle_numb,
        if (pict.Name != "pictureBox1")
        {
            pict.Location = new Point(pict.X, pict.Y-10);
        }
    }
