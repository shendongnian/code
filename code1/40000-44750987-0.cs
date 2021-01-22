      con.Open();
    sqlQuery = "INSERT INTO [dbo].[Client] ([Client_ID],[Client_Name],[Phone],[Address],[Image]) VALUES('" + txtClientID.Text + "','" + txtClientName.Text + "','" + txtPhoneno.Text + "','" + txtaddress.Text + "',@image)";
                    cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.Add("@image", SqlDbType.Image);
                    cmd.Parameters["@image"].Value = img;
                //img is a byte object
               ** /*MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms,pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();*/**
                    cmd.ExecuteNonQuery();
                    con.Close();
