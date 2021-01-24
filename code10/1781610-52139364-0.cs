    private void SetUpPuzzle_Click(int parts)  // use the number of parts on each side
    {
        Control board = panel1;  // use the control you want to use or the form!
        int total = parts * parts;
        var PB = new PictureBox[total];
        var imgarray = new Image[total];
        var img = User_Image.Image;
        int W = img.Width / parts;
        int H = img.Height / parts;
        for (int i = 0; i < parts; i++)
        {
            for (int j = 0; j < parts; j++)
            {
                var index = i * parts + j;
                imgarray[index] = new Bitmap(W, H);
                using (Graphics graphics = Graphics.FromImage(imgarray[index]))
                    graphics.DrawImage(img, new Rectangle(0, 0, W, H), 
                                       new Rectangle(i * W, j * H, W, H), GraphicsUnit.Pixel);
                PB[index] = new PictureBox
                {
                    Name = "P"+ index,
                    Size = new Size(100, 100),
                    Location = new Point(i * 100, j * 100),
                    Image = imgarray[index],
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                PB[index].MouseEnter += Images_M_E;
                PB[index].MouseLeave += Images_M_L;
                board.Controls.Add(PB[index]);
            }
        }
    }
