                foreach (GridViewRow gvrow in grdUSPS.Rows)
                {
                      CheckBox chk = (CheckBox)gvrow.FindControl("chkSelect");
                    if (chk.Checked)
                    {
                    string fileName = gvrow.Cells[1].Text;
                    
                    string filePath = Server.MapPathfilename);
                    zip.AddFile(filePath, "files");
                    }
                }
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=DownloadedFile.zip");
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                Response.End();
            
