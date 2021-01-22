    protected void Button1_Click(object sender, EventArgs e)
        {
    Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            string HIJRA_TODAY = "01/10/1435";
            ReportParameter[] param = new ReportParameter[3];
            param[0] = new ReportParameter("CUSTOMER_NUM", CUSTOMER_NUMTBX.Text);
            param[1] = new ReportParameter("REF_CD", REF_CDTB.Text);
            param[2] = new ReportParameter("HIJRA_TODAY", HIJRA_TODAY);
            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename= filename" + "." + extension);
            Response.OutputStream.Write(bytes, 0, bytes.Length); // create the file  
            Response.Flush(); // send it to the client to download  
            Response.End();
}    
