            Response.ContentType = "application/msword";
            Response.ContentEncoding = System.Text.UnicodeEncoding.UTF8;
            Response.Charset = "UTF-8";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + "mydoc.doc");
            Response.Write("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='http://www.w3.org/TR/REC-html40'>");
            Response.Write("<head>");
            Response.Write("<!--[if gte mso 9]> <xml> <w:WordDocument> <w:View>Print</w:View> <w:Zoom>100</w:Zoom> <w:DoNotOptimizeForBrowser/> </w:WordDocument> </xml> <![endif]-->");
            Response.Write("<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"\"text/html; charset=UTF-8\"\">");
            Response.Write("<meta name=ProgId content=Word.Document>");
            Response.Write("<meta name=Generator content=\"Microsoft Word 9\">");
            Response.Write("<meta name=Originator content=\"Microsoft Word 9\">");
            Response.Write("</head>");
            Response.Write("<body>");
            Response.Write("<div class=Section2>");
            // write some content here
            Response.Write("</body>");
            Response.Write("</html>");
            HttpContext.Current.Response.Flush();
