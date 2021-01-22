     protected void btnUpload_click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool logval = true;
                if (logval == true)
                {
                    if (fuUploadExcelName.HasFile)
                    {
                        String img_1 = fuUploadExcelName.PostedFile.FileName;
                        String img_2 = System.IO.Path.GetFileName(img_1);
                        string extn = System.IO.Path.GetExtension(img_1);
                        string frstfilenamepart = "Text" + DateTime.Now.ToString("ddMMyyyyhhmmss");
                        UploadExcelName.Value = frstfilenamepart + extn;
                        fuUploadExcelName.SaveAs(Server.MapPath("~/Text/") + "/" + UploadExcelName.Value);
    
                        string filename = UploadExcelName.Value;
                        string filePath = Server.MapPath("~/Text/" + filename);
                        StreamReader file = new StreamReader(filePath);
                        string[] ColumnNames = file.ReadLine().Split('#');
                        DataTable dt = new DataTable();
                        foreach (string Column in ColumnNames)
                        {
                            dt.Columns.Add(Column);
                        }
                        string NewLine;
                        while ((NewLine = file.ReadLine()) != null)
                        {
                            DataRow dr = dt.NewRow();
                            string[] values = NewLine.Split('#');
    
                            for (int i = 0; i < values.Length; i++)
                            {
                                dr[i] = values[i].TrimEnd();
                            }
                            dt.Rows.Add(dr);
                        }
                        file.Close();
                        grdview.DataSource = dt;
                        grdview.DataBind();
                       
                       
                    }
                }
    
            }
        }
