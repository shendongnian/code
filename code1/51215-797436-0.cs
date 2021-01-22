    #region "Var Delaration"
    public string gh;
    public string strResponsePageContent = string.Empty;
    public string strIndividualResponsePagesLocation = string.Empty;
    StreamReader srDefaultIndiResponsePage = null;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void GenerateMsWordDoc(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //strIndividualResponsePagesLocation = HttpRuntime.AppDomainAppPath + "Survey/IndividualResponseWordCss.txt";
        //srDefaultIndiResponsePage = new StreamReader(strIndividualResponsePagesLocation);
        //strResponsePageContent = srDefaultIndiResponsePage.ReadToEnd();  
        //System.Web.HttpResponse oResponse = System.Web.HttpContext.Current.Response;
        Response.Clear();
        Response.Buffer = true;
        Response.ContentEncoding = System.Text.Encoding.UTF7;
        System.Text.StringBuilder SB = new System.Text.StringBuilder();
        System.IO.StringWriter SW = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlTW = new System.Web.UI.HtmlTextWriter(SW);
        tbl.RenderControl(htmlTW);
        string strBody = "<html>" +
            "<body>" + "<div><b>" + htmlTW.InnerWriter.ToString() + "</b></div>" +
            "</body>" +
            "</html>";
        //string strBody = "<html>" + "<body>" + strResponsePageContent.ToString() + htmlTW.InnerWriter.ToString() + "</body>" +
        //   "</html>";      
        string fileName = "MsWordSample.doc";
        // You can add whatever you want to add as the HTML and it will be generated as Ms Word docs
        Response.AppendHeader("Content-Type", "application/msword");
        Response.AppendHeader("Content-disposition", "attachment; filename=" + fileName);
        Response.ContentEncoding = System.Text.Encoding.UTF7;
        string fileName1 = "C://Temp/Excel" + DateTime.Now.Millisecond.ToString();
        BinaryWriter writer = new BinaryWriter(File.Open(fileName1, FileMode.Create));
        writer.Write(strBody);
        writer.Close();
        FileStream fs = new FileStream(fileName1, FileMode.Open, FileAccess.Read);
        byte[] renderedBytes;
        // Create a byte array of file stream length 
        renderedBytes = new byte[fs.Length];
        //Read block of bytes from stream into the byte array 
        fs.Read(renderedBytes, 0, System.Convert.ToInt32(fs.Length));
        //Close the File Stream 
        fs.Close();
        FileInfo TheFile = new FileInfo(fileName1);
        if (TheFile.Exists)
        {
            File.Delete(fileName1);
        }
        Response.BinaryWrite(renderedBytes);
        Response.Flush();
        Response.End();
    }
