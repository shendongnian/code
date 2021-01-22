    function byte[] CreatePdf(){
                byte[] result;
                using (MemoryStream ms = new MemoryStream())
                {
                    Document pDoc = new Document(PageSize.A4, 0, 0, 0, 0);
                    PdfWriter writer = PdfWriter.GetInstance(pDoc, ms);
                    pDoc.Open();
    
                    //here you can create your own pdf.
    
                    pDoc.Close();
                    result = ms.GetBuffer();
                }
    
                return result;
    }
