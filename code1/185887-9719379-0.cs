    ***//       This code made by Syed baqar hassan.
    //       E_Mail Add : baqar.hassan110@yahoo.com
    //Arrange the Picture Of Path.***
    
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
    
                        string[] PicPathArray;
                        string ArrangePathOfPic;
    
                        PicPathArray = openFileDialog1.FileName.Split('\\');
    
                        ArrangePathOfPic = PicPathArray[0] + "\\\\" + PicPathArray[1];
                        for (int a = 2; a < PicPathArray.Length; a++)
                        {
                            ArrangePathOfPic = ArrangePathOfPic + "\\\\" + PicPathArray[a];
                        }
                   }
    ***![// Save the path Of Pic in database][1]***
    // Save the path Of Pic in database
    
                        SqlConnection con = new SqlConnection("Data Source=baqar-pc\\baqar;Initial Catalog=Prac;Integrated Security=True");
                        con.Open();
    
                        SqlCommand cmd = new SqlCommand("insert into PictureTable (Pic_Path) values (@Pic_Path)", con);
                        cmd.Parameters.Add("@Pic_Path", SqlDbType.VarChar).Value = ArrangePathOfPic;
    
                        cmd.ExecuteNonQuery();
    
    ***// Get the Picture Path in Database.***
    
    SqlConnection con = new SqlConnection("Data Source=baqar-pc\\baqar;Initial Catalog=Prac;Integrated Security=True");
                    con.Open();
    
                    SqlCommand cmd = new SqlCommand("Select * from Pic_Path where ID = @ID", con);
    
                    SqlDataAdapter adp = new SqlDataAdapter();
                    cmd.Parameters.Add("@ID",SqlDbType.VarChar).Value = "1";
                    adp.SelectCommand = cmd;
    
                    DataTable DT = new DataTable();
    
                    adp.Fill(DT);
    
                    DataRow DR = DT.Rows[0];
                    pictureBox1.Image = Image.FromFile(DR["Pic_Path"].ToString());
    
    
    *****//       This code made by Syed baqar hassan.
    //       E_Mail for Feedback : baqar.hassan110@yahoo.com*****
    
    
      [1]: http://i.stack.imgur.com/LL2qD.png
