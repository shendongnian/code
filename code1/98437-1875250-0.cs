    if (Controller.ValidateFileExist())
            {
                ClearFields();
                Response.Clear();
                Response.ContentType = "text/plain";
                Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "FileNAme.Ext"));
                Response.TransmitFile(FileNAme.Ext);
                Response.End();
                Controller.DeleteFile();
            }
