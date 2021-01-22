    protected void Page_Load(object sender, EventArgs e)
            {
                Response.Clear();
                Response.AppendHeader("content-disposition", "attachment; filename=myfile.xml");
                Response.ContentType = "text/xml";
                UTF8Encoding encoding = new UTF8Encoding();
                Response.BinaryWrite(encoding.GetBytes("my string"));
                Response.Flush();
                Response.End();
            }
