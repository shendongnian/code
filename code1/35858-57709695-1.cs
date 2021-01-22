            private void webbrowse_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        // btnscreenshot.Visible = false;
        string folderPath = Server.MapPath("~/ImageFiles/");
        WebBrowser webrowse = sender as WebBrowser;
        //Bitmap bitmap = new Bitmap(webrowse.Width, webrowse.Height);
        Bitmap bitmap = new Bitmap(webrowse.Width, webrowse.Height, PixelFormat.Format16bppRgb565);
        webrowse.DrawToBitmap(bitmap, webrowse.Bounds);
     
        string Systemimagedownloadpath = System.Configuration.ConfigurationManager.AppSettings["Systemimagedownloadpath"].ToString();
        string fullOutputPath = Systemimagedownloadpath + Request.QueryString["VisitedId"].ToString() + ".png";
        MemoryStream stream = new MemoryStream();
        bitmap.Save(fullOutputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        //generating pdf code 
         Document pdfDoc = new Document(new iTextSharp.text.Rectangle(1100f, 20000.25f));
         PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
         pdfDoc.Open();
         iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(fullOutputPath);   
         img.ScaleAbsoluteHeight(20000);
         img.ScaleAbsoluteWidth(1024);     
         pdfDoc.Add(img);
         pdfDoc.Close();
         //Download the PDF file.
         Response.ContentType = "application/pdf";
         Response.AddHeader("content-disposition", "attachment;filename=ImageExport.pdf");
         Response.Cache.SetCacheability(HttpCacheability.NoCache);
         Response.Write(pdfDoc);
         Response.End();
        
    }
