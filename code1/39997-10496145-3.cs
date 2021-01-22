     public bool convertImage()
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                photo = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo, 0, photo.Length);
                return true;
            }
            catch
            {
                MessageBox.Show("image can not be converted");
                return false;
            }
        }
        public void insertImage()
        {
           // SqlConnection con = new SqlConnection();
            try
            {
                cs.Close();
                cs.Open();
                da.UpdateCommand = new SqlCommand("UPDATE All_students SET disco = " +photo+" WHERE Reg_no = '" + Convert.ToString(textBox1.Text)+ "'", cs);
                da.UpdateCommand.ExecuteNonQuery();
                cs.Close();
                cs.Open();
                int i = da.UpdateCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Successfully Inserted...");
                }
            }
            catch
            {
                MessageBox.Show("Error in Connection");
            }
            cs.Close();
        }
