            string query="SELECT * from gym_member where Registration_No ='" + textBox9.Text + "'";
                
            command = new SqlCommand(query,con);
            ad = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            textBox1.Text = dt.Rows[0][1].ToString();
            textBox2.Text = dt.Rows[0][2].ToString();
            byte[] img = (byte[])dt.Rows[0][18];
            MemoryStream ms = new MemoryStream(img);
          
            pictureBox1.Image = Image.FromStream(ms);
            ms.Dispose();
