    int w=75, h = 65;
     PictureBox picture = new PictureBox
                    {
                        Name = "pictureBox" + i,
                        Size = new Size(70, 60),
                        Location = new Point(x + i%columns * w, y + i/columns * h),
                        BorderStyle = BorderStyle.Fixed3D,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Visible = true
                    };
