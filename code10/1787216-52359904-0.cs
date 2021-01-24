    string co = null;
    string na = null;
    string le = null;
    string gn = null;
    string A = "pak";
    try
    {
        MySqlCommand cmd = new MySqlCommand("Select Code,Name,LifeExpectancy,GNP,flg from country where Name REGEXP '" + A + "'", connection);
        MySqlDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            BitmapImage bi = new BitmapImage();
            co = dataReader["Code"].ToString();
            na = dataReader["Name"].ToString();
            le = dataReader["LifeExpectancy"].ToString();
            gn = dataReader["GNP"].ToString();
            Byte[] bindata = (Byte[])dataReader["flg"];
            MemoryStream strm = new MemoryStream();
            strm.Write(bindata, 0, bindata.Length);
            strm.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(strm); 
            bi.BeginInit();
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms; 
            bi.EndInit();
            dt.Rows.Add(co, na, le, gn, bi);
            dataGridCustomers.ItemsSource = dt.DefaultView;
        }
    }
    catch (MySqlException ex)
    {
           MessageBox.Show(ex.ToString());
    }
