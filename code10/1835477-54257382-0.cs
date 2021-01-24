    public async Task<BitmapImage> GetBitmap(string ConnectingString, string SQLCode)
    {
        SqlConnection con1 = new SqlConnection(ConnectingString);
        //Open Connection String
        await con1.OpenAsync();
        // load image from the database 
        SqlCommand Commandcmd = new SqlCommand(SQLCode, con1);
        BitmapImage myBitmapImage = new BitmapImage();
        SqlDataReader rdr1 = null;
        rdr1 = await Commandcmd.ExecuteReaderAsync();
        while (await rdr1.ReadAsync())
        {
            if (rdr1 != null)
            {
                if (rdr1[0] != DBNull.Value)
                {
                    byte[] data = (byte[])rdr1[0]; // 0 is okay if you only selecting one column
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
                    {
                        // BitmapImage.UriSource must be in a BeginInit/EndInit block
                        myBitmapImage.BeginInit();
                        myBitmapImage.StreamSource = ms;
                        myBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        myBitmapImage.DecodePixelHeight = 500;
                        myBitmapImage.DecodePixelWidth = 500;
                        myBitmapImage.EndInit();
                        myBitmapImage.Freeze();
                    }
                    return myBitmapImage;
                }
            }
        }
        return myBitmapImage;
    }
