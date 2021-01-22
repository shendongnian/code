               protected void Page_Load(object sender, EventArgs e){      
                //Create connection to mysql database.
                MySqlConnection conn = new MySqlConnection(db);
                conn.Open();
                string s;
                s = Session["t"].ToString();
                string commantext = "select img_id,img_file,img_type,img_name from image where img_name='"+s+"'";
               MySqlCommand cmd = new MySqlCommand(commantext,conn);
                cmd.Parameters.Add("?img_id", MySqlDbType.Int32).Value = s;
                
               //create datatable. GetData is a method to fetch the data.
               DataTable dt = GetData(cmd);
               //Get data from database to bytes.
               Byte[] bytes = (Byte[])dt.Rows[0]["img_file"];
 
               //Defining the size to display data.
               int outputSize = 100;
                    if (bytes.Length > 0)
                    {
                        // Open a stream for the image and write the bytes into it
                        System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes, true);
                        stream.Write(bytes, 0, bytes.Length);
                        Bitmap bmp = new Bitmap(stream);
                        Size new_size = new Size();
                        //resize based on the longer dimension
                        if (bmp.Width > bmp.Height)
                        {
                            new_size.Width = outputSize;
                            new_size.Height = (int)(((double)outputSize / (double)bmp.Width) * (double)bmp.Height);
                           
                        }
                        else
                        {
                            new_size.Width = (int)(((double)outputSize / (double)bmp.Height) * (double)bmp.Width);                            
                            new_size.Height = outputSize;
                           
                        }
                        Bitmap bitmap = new Bitmap(new_size.Width, new_size.Height, bmp.PixelFormat);
                        Graphics new_g = Graphics.FromImage(bitmap);
                        new_g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        new_g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        new_g.DrawImage(bmp, -1, -1, bitmap.Width + 1, bitmap.Height + 1);
                        bmp.Dispose();
                        bitmap.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        bitmap.Dispose();
                        new_g.Dispose();
                        stream.Close();
                    }
                 }
    private DataTable GetData(MySqlCommand cmd)
    {
        DataTable dt = new DataTable();
        //String strConnString = System.Configuration.ConfigurationManager    .ConnectionStrings["conString"].ConnectionString;
        MySqlConnection con = new MySqlConnection(db);
        MySqlDataAdapter sda = new MySqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch
        {            return null;
        }
        finally
        {   con.Close();
            sda.Dispose();
            con.Dispose();
        }
    }
    }
