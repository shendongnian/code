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
                BitmapImage bi = new BitmapImage();
                using (MemoryStream strm = new MemoryStream(_photo))
                {
                    bi.BeginInit();
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.StreamSource = strm;
                    bi.EndInit();
                }
                image1.Source = bi;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
