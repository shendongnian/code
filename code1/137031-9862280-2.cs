     public Byte[] Ret_image(Int32 id)
    
        {
    
            SqlCommand cmd = new SqlCommand();
    
            cmd.CommandText = "select*from tbimage where imageid=@id";
    
            cmd.Connection = con;
    
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
    
            SqlDataReader dr = cmd.ExecuteReader();
    
            dr.Read();
    
            Byte[] ar = (Byte[])(dr[1]);
    
            dr.Close();
    
            cmd.Dispose();
    
            return ar;
    
        }
    
        protected void btnRetImage_Click(object sender, EventArgs e)
    
        {
    
            try
    
            {
    
                Byte[] ar = Ret_image(Convert.ToInt32(TextBox2.Text));
    
                String st = Server.MapPath("abc.jpg");
    
                FileStream fs = new FileStream(st, FileMode.Create, FileAccess.Write);
    
                fs.Write(ar, 0, ar.Length);
    
                fs.Close();
    
                Image1.Visible = true;
    
                Image1.ImageUrl = "abc.jpg";
    
                Label1.Visible = false;
    }
    catch(Expration exp)
    {
     Label1.Text = "Wrong Image id";
    
                Label1.Visible = true;
    
                Image1.Visible = false;
    
            }
    
        }
    
    }
