            SqlConnection con = new SqlConnection(@"Data Source=HITMAN-PC\MYSQL;
            Initial Catalog=Payam;
            Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select * from news", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
                string adress = dt.Rows[i]["ImgLink"].ToString();
                ImageSource imgsr = new BitmapImage(new Uri(adress));
                PnlImg.Source = imgsr;
           
