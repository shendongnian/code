    if (jugador.Foto != null)
    {
        using(MemoryStream ms = new MemoryStream())
        {
            ms.Write(jugador.Foto, 0, Convert.ToInt32(jugador.Foto.Length));
            ms.Seek(0, SeekOrigin.Begin); // seek to the beginning of the stream
            Bitmap bm = new Bitmap(ms, false);
            pictureBox1.Image = bm;
        }
    }
