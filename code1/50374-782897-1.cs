    filena = filena.Replace(".mp3", ".jpg");
    if (filena.Length > 0)
    {
        pictureBox1.Image = new System.Drawing.Bitmap(filena); 
    }
