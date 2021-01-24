    public void loadimg()
    {
        con.Open();
        OleDbCommand cmd = new OleDbCommand("Select * from recents", con);
        OleDbDataReader _dr;
        _dr = cmd.ExecuteReader;
        byte[] _photo;
        while (_dr.Read())
        {
            try
            {
                _photo = (byte[])_dr(1);
                MemoryStream strm = new MemoryStream(_photo);
                System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                bi.StreamSource = ms;
                bi.EndInit();
                image1.Source = bi;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
