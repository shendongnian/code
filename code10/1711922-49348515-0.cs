    protected void exportBtn_Click(object sender, EventArgs e)
            {
    
                string filename = "Results_" + DateTime.Now.ToString("ddMMyyyy")+".xls";
                Response.Clear();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", filename));
                Response.ContentEncoding = Encoding.UTF8;
                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(stringWriter);
                resultTable.RenderControl(hw);
                Response.Write(stringWriter.ToString());
                Response.End();
    
            }
