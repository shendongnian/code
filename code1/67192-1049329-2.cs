    protected void Button1_Click(object sender, EventArgs e)
            {
                string fileName = @"c:\SecureDirectory\DownloadableFile.txt";
                int exipireMinutes = -10;
    
                if (System.IO.File.Exists(fileName) && System.IO.File.GetCreationTime(fileName) >= DateTime.Now.AddMinutes(exipireMinutes))
                {
                    byte[] fileBinary;
                    using (System.IO.FileStream fs = System.IO.File.Open(Server.MapPath(fileName), System.IO.FileMode.Open))
                    {
                        fileBinary = new byte[fs.Length];
                        fs.Read(fileBinary, 0, Convert.ToInt32(fs.Length));
                    }
                    Response.AddHeader("Content-disposition", "attachment; filename=" + fileName);
                    Response.ContentType = "application/octet-stream";
                    Response.BinaryWrite(fileBinary);
                    Response.End();
                }
            }
