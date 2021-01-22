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
