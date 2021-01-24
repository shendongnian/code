      using ClosedXML.Excel;
     protected void uploadLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                string FileName = Path.GetFileName(StyleOperationsFileUpload.PostedFile.FileName);
                string FolderPath = Server.MapPath("~/Downloads/" + FileName);
                StyleOperationsFileUpload.SaveAs(FolderPath);
                using (XLWorkbook workbook = new XLWorkbook(FolderPath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);
                    DataTable DatTab = new DataTable();
                    bool FirstRow = true;
                    foreach (IXLRow row in worksheet.Rows())
                    {
                        if (FirstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
                            {
                                DatTab.Columns.Add(cell.Value.ToString());
                            }
                            FirstRow = false;
                        }
                        else
                        {
                            DatTab.Rows.Add();
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                DatTab.Rows[DatTab.Rows.Count - 1][i] = cell.Value.ToString();
                                i++;
                            }
                        }
                    }
                    UploadGridView.DataSource = DatTab;
                    UploadGridView.DataBind();
                }
                SaveLinkButton.Enabled = true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please Restart the system: " + ex + "')</script>");
            }
            
        }
