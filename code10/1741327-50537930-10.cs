    <%@ WebHandler Language="C#" Class="ShowPDF" %>
    
    using System;
    using System.Web;
    using System.Web.SessionState; // Added manually.
    using System.IO; // Added manually.
    /* IMPORT YOUR PDF'S LIBRARIES HERE */
    
    // You'll have to add 'IReadOnlySessionState' manually.
    public class ShowPDF : IHttpHandler, IReadOnlySessionState {
    
        public void ProcessRequest (HttpContext context)  {
            // Do your PDF proccessing here.
            
            // Get sb from the session variable.
            string sb = context.Session["sb"].ToString();
    
                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
    
    
                    Response.End();
               
        }
    
        public bool IsReusable {
            get {
                return false;
            }
        }
    
    }
