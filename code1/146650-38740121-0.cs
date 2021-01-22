              Byte[] img;
            con.Open();
            OracleCommand command = new OracleCommand("Select Image as BLOBDATA FROM tbltestImage ", con);
            command.InitialLONGFetchSize = -1;
            OracleDataReader rdr = command.ExecuteReader();
            
            DataTable dt = new DataTable();
            dt.Load(rdr);
            con.Close();
             if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["BLOBDATA"].ToString() != "")
                {
                  
                    img = (Byte[])dt.Rows[0]["BLOBDATA"];
                    
                    MemoryStream ms = new MemoryStream(img);
                    Bitmap bitmap = new Bitmap(ms);
                    pictureBox2.Image = bitmap;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            
            
            
            
            }
