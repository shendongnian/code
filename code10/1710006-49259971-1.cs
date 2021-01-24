     private void LoadLoggedInUsersDetails()
    {
    con.Open();
    SqlCommand cmd2 = new SqlCommand("Select * from userinfo where ID='" + idStringHere + "'", con);
    byte[] photo;
    SqlDataReader dr2 = cmd2.ExecuteReader;
    while (dr2.Read)
    {
        photo = (byte[])dr2(11);
        MemoryStream strm = new MemoryStream(photo);
        BitmapImage bi = new BitmapImage;
        bi.BeginInit();
        strm.Seek(0, SeekOrigin.Begin);
        bi.StreamSource = strm;
        bi.EndInit();
        imageControl.ImageSource = bi;
    }
    con.Close();
    }
