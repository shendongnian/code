    MemoryStream ms;
    
    using (ms = new MemoryStream())
    {
       PdfWriter writer = PdfWriter.GetInstance(myPdfDoc, ms);
    
       Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
       Response.OutputStream.Flush();
       Response.OutputStream.Close();
    }
}
