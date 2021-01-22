    try
       {
           con.Open();
           if ((fileUpload1.PostedFile != null) && (fileUpload1.PostedFile.ContentLength > 0))
           {
               filename = System.IO.Path.GetFileName(fileUpload1.PostedFile.FileName);
               ext = System.IO.Path.GetExtension(filename).ToLower();
               string str=@"/Resumes/" + filename;
               saveloc = (Server.MapPath(".") + str);
               string[] exts = { ".doc", ".docx", ".pdf", ".rtf" };
               for (int i = 0; i < exts.Length; i++)
               {
                   if (ext == exts[i])
                       fileok = true;
               }
               if (fileok)
               {
                   if (File.Exists(saveloc))
                       throw new Exception(Label1.Text="File exists!!!");
                   fileUpload1.PostedFile.SaveAs(saveloc);
                   cmd = new SqlCommand("insert into candidate values('" + candidatename + "','" + candidatemail + "','" + candidatemobile + "','" + filename + "','" + str + "')", con);
                   cmd.ExecuteNonQuery();
                   Label1.Text = "Upload Successful!!!";
                   Label1.ForeColor = System.Drawing.Color.Blue;
                   con.Close();
               }
               else
               {
                   Label1.Text = "Upload not successful!!!";
                   Label1.ForeColor = System.Drawing.Color.Red;
               }
           }
           
        }
       catch (Exception ee) { Label1.Text = ee.Message; }
