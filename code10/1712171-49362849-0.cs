    protected void btn_Click(object sender, EventArgs e)
        {
            
            string filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("File/" + filename));
            string CurrentFilePath = Server.MapPath("File/" + filename);
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + CurrentFilePath + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            DataTable Sheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            
            foreach (DataRow dr in Sheets.Rows)
            {
                string sht = dr[2].ToString().Replace("'", "");
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From [" + sht + "]", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                 
            }
            
        }
