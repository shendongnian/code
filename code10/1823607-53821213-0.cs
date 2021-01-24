            FileStream fs = new FileStream(selectedFile, FileMode.Open, FileAccess.Read);
            byte[] bimage = new byte[fs.Length];
            fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
            SqlConnection cn;
            cn = new SqlConnection("Data Source=.;Initial Catalog=TestDB;Integrated 
            Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("insert into MyTable (Image) 
            values(@imgdata)", cn);
            cmd.Parameters.AddWithValue("@imgdata", SqlDbType.Image).Value = bimage;
            cmd.ExecuteNonQuery();
            cn.Close();
