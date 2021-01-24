    public ActionResult RedBluePDF(string community, string procedure) 
    { 
       var model = new GeneratePDFModel(); 
       var pdf= new Rotativa.ViewAsPdf("GeneratePDF", model){
            FileName = "TestViewAsPdf.pdf"
       }
       var bytes = pdf.BuildFile(); // byte array
       // do what you want with the byte array here
    }
