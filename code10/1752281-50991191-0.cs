    // Save file and send to client browser using selected format
    if (yourFileFormat == "XLS")
    {
    	workbook.Save(HttpContext.Current.Response, "output.xls", ContentDisposition.Attachment, new XlsSaveOptions(SaveFormat.Excel97To2003));
    }
    else
    {
    	workbook.Save(HttpContext.Current.Response, "output.xlsx", ContentDisposition.Attachment, new OoxmlSaveOptions(SaveFormat.Xlsx));
    }
    
    HttpContext.Current.Response.End();
