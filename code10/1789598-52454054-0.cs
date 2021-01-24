    //  size of the boxes
    Size size = new Size(70, 60);
    
    int totalBoxes = rows * columns;
    List<PictureBox> pictureBoxList = new List<PictureBox>();
    for (int i = 0; i < totalBoxes; i++)
    {
        int curentColumn = i % columns;
        int currentRow = i / columns;
        int curentX = x + curentColumn * size.Width;
        int curentY = y + currentRow * size.Height;
        PictureBox picture = new PictureBox
        {
            Name = "pictureBox" + i,
            Size = size,
            Location = new Point(curentX, curentY),
            BorderStyle = BorderStyle.Fixed3D,
            SizeMode = PictureBoxSizeMode.Zoom,
            Visible = true
        };
        this.Controls.Add(picture);
        pictureBoxList.Add(picture);
    }
