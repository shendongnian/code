    Example of text file format
    
    Code#Name#Fathername#DOB#Location#MobileNo
    1#XYZ#YYY#09-06-89#LKO#9999999999
    
    
    
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
                            string frstfilenamepart = "Text" + DateTime.Now.ToString("ddMMyyyyhhmmss");/*Filename for storing in Desired path*/
                            UploadExcelName.Value = frstfilenamepart + extn;
                            fuUploadExcelName.SaveAs(Server.MapPath("~/Text/") + "/" + UploadExcelName.Value);/*Uploaded text file will be store at this path*/
        
                            string filename = UploadExcelName.Value;
                            string filePath = Server.MapPath("~/Text/" + filename);
    
    
    
    
                            StreamReader file = new StreamReader(filePath);
                            string[] ColumnNames = file.ReadLine().Split('#');/*read data from textfile*/
                            DataTable dt = new DataTable();
                            foreach (string Column in ColumnNames)
                            {
                                dt.Columns.Add(Column);/*adding the columns/
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
                            grdview.DataSource = dt;/*make datasouce from text file*
                            grdview.DataBind();/*binding the grid*/
                           
                           
                        }
                    }
        
                }
            }
