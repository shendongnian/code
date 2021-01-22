    protected void btnGetFile_Click(object sender, EventArgs e)
            {
                string title = "DischargeSummary.pdf";
                string contentType = "application/pdf";
                byte[] documentBytes = GetDoc(DocID);
    
                Response.Clear();
                Response.ContentType = contentType;
                Response.AddHeader("content-disposition", "attachment;filename=" + title);
                Response.BinaryWrite(documentBytes);
                Response.End();
            }
