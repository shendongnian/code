            MemoryStream memStream = new MemoryStream();
            TextReader xmlString = new StringReader(outXml);
            using (Document document = new Document())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memStream);
                //document.SetPageSize(iTextSharp.text.PageSize.A4);
                document.Open();
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(outXml);
                MemoryStream ms = new MemoryStream(byteArray);
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, ms, System.Text.Encoding.UTF8);
                document.Close();
            }
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(memStream.ToArray());
            Response.End();
            Response.Flush();
