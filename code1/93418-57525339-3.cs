    public ActionResult DisplayPDF()
    {
        byte[] byteArray = GetPdfFromWhatever();
        
        return new FileContentResult(byteArray, "application/pdf");
    }
