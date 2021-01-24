    //  size of the boxes
    Size size = new Size(70, 60);
    int totalBoxes = rows * columns;
    List<PictureBox> pictureBoxList = new List<PictureBox>();
    for (int row = 0; row < rows; row++)
    {
        int curentY = y + row * size.Height;
        for (int col = 0; col < columns; col++)
        {
            int curentX = x + col * size.Width;
            PictureBox picture = new PictureBox
            {
                Name = "pictureBox" + (row + col),
                Size = size,
                Location = new Point(curentX, curentY),
                BorderStyle = BorderStyle.Fixed3D,
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = true
            };
            this.Controls.Add(picture);
            pictureBoxList.Add(picture);
        }
    }
