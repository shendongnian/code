    private void button2_Click(object sender, EventArgs e)
        {
            string str = "select photo from tbl_img where id='" + textBox2.Text + "'";
 
            string ConStr = @"Server=COMP7;Database=ImageTest;User Id=sa;Password=cos123";
 
            SqlConnection con = new SqlConnection(ConStr); 
 
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataTable dt = new DataTable();
 
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                byte[] imgdata = new byte[0];
                imgdata = (byte[])dt.Rows[0][0];
                MemoryStream ms = new MemoryStream(imgdata);
                pictureBox2.Image = Image.FromStream(ms);      
            }
            else
            {
                MessageBox.Show("No images in a table");
            }
        }
