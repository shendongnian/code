    using System; 
    using System.IO; 
    using System.Web; 
    using System.Web.UI; 
    using System.Web.UI.WebControls; 
    using iTextSharp.text; 
    using iTextSharp.text.html.simpleparser; 
    using iTextSharp.text.pdf; 
     
    public partial class utilities_getPDF : System.Web.UI.Page 
    { 
        protected void Page_PreInit(object sender, EventArgs e) 
        { 
            // add user controls to the page 
            AddContentControl("controls/page1"); 
            AddContentControl("controls/page2"); 
            AddContentControl("controls/page3"); 
      
        } 
        //  the parts are probably irrelevant to the question... 
        private const string contentPage = "~/includes/{0}.ascx"; 
        private void AddContentControl(string page) 
        { 
            content.Controls.Add(myLoadControl(page)); 
        } 
        private Control myLoadControl(string page) 
        { 
            return TemplateControl.LoadControl(string.Format(contentPage, page)); 
        } 
    
        protected override void Render(HtmlTextWriter writer)
        {
            //ignore asp.net writer and use your own.
            //base.Render(writer);    
            // set up the response to download the rendered PDF... 
            Response.ContentType = "application/pdf"; 
            Response.ContentEncoding = System.Text.Encoding.UTF8; 
            Response.AddHeader("Content-Disposition", "attachment;filename=FileName.pdf"); 
            Response.Cache.SetCacheability(HttpCacheability.NoCache); 
     
            // get the rendered HTML of the page 
            System.IO.StringWriter stringWrite = new StringWriter(); 
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite); 
            base.Render(htmlWrite); 
            htmlWrite.Flush();
            htmlWrite.Close();
            StringReader reader = new StringReader(stringWrite.ToString()); 
            System.IO.MemoryStream stream = new MemoryStream();
            // write the PDF to the OutputStream... 
            Document doc = new Document(PageSize.A4); 
            HTMLWorker parser = new HTMLWorker(doc); 
            PdfWriter.GetInstance(doc, stream); 
            doc.Open(); 
            parser.Parse(reader); 
            doc.Close(); 
    
            //binary write your pdf file
            Response.Clear();
            Response.BinaryWrite(stream.GetBuffer());
            Response.End();
    
        }
    } 
    
    
