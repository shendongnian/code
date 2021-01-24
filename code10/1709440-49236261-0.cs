     protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileUpload.PostedFiles.Count <= 6)
                {
                    int a = fileUpload.PostedFile.ContentLength;
                    if (a < 2000)
                    {
                        foreach (HttpPostedFile postedFile in fileUpload.PostedFiles)
                        {
                            string filename = Path.GetFileName(postedFile.FileName);
                            string contentType = postedFile.ContentType;
                            using (Stream fs = postedFile.InputStream)
                            {
                                using (BinaryReader br = new BinaryReader(fs))
                                {
                                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
    
                                    using (SqlConnection con = new SqlConnection(@"Data Source= USER\SQLEXPRESS ; Initial Catalog= BlobUploading ; Integrated Security = True"))
                                    {
                                        string query = "insert into tblBlob values (@BloB1, @BloB2, @BloB3,@BloB4 ,@BloB5 ,@BloB6)";
                                        using (SqlCommand cmd = new SqlCommand(query))
                                        {
                                            cmd.Connection = con;
                                            cmd.Parameters.AddWithValue("@BloB1", bytes[0]);
                                            cmd.Parameters.AddWithValue("@BloB2", bytes[1]);
                                            cmd.Parameters.AddWithValue("@BloB3", bytes[2]);
                                            cmd.Parameters.AddWithValue("@BloB4", bytes[3]);
                                            cmd.Parameters.AddWithValue("@BloB5", bytes[4]);
                                            cmd.Parameters.AddWithValue("@BloB6", bytes[5]);
                                            con.Open();
                                            cmd.ExecuteNonQuery();
                                            con.Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
