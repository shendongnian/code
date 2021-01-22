    public void Draw() {
        Bitmap bmp = new Bitmap(240,320);
        using(Graphics g = Graphics.FromImage(bmp))
        {
            // draw something with Graphics here.
            g.Clear(Color.Black);
            g.DrawImage(Images.CloseIcon, 16, 48);
            g.DrawImage(Images.RefreshIcon, 46, 48);
            g.FillRectangle(new SolidBrush(Color.Black), 0, 100, 240, 103);
            //Backup old image in pictureBox
            var oldImage = pictureBox.Image;
            pictureBox.Image = bmp; 
            //Release resources from old image
            if(oldImage != null)
                ((IDisposable)oldImage).Dispose();            
        }
    }
