    Bitmap bm = ...;    
    using (Graphics gr = Graphics.FromImage(bm))
    {
        gr.DrawRectangle(somePoint, someRectangle);
    }
    pictureBox.Image = bm;
