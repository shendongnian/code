    var cdhv= new ContentDispositionHeaderValue("inline");
    cdhv.SetHttpFileName( attachmentFileName);
    Response.Headers["Content-Disposition"] = cdhv.ToString();
    if(mimeType == "application/pdf"){
        SelectPdf.PdfDocument doc = null;
        try{
            doc = new SelectPdf.PdfDocument(fullPath);
            var docinfo = doc.DocumentInformation;
            docinfo.Title = attachmentFileName;
            doc.Save(Response.Body);
        }finally{
            doc?.Close();
        }
    }else{
        Response.Body.Write(content);
    }
    return ;
