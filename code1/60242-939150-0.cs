    PrintJob oPrintJob = null;
    switch (type)
    {
        case convert2pdf.ConvertFileType.Word: 
            oPrintJob = new WordPrintJob(); 
            break;
        case convert2pdf.ConvertFileType.Excel: 
            oPrintJob = new ExcelPrintJob(); 
            break;
        case convert2pdf.ConvertFileType.PowerPoint: 
            oPrintJob = new PowerPointPrintJob(); 
            break;
        case convert2pdf.ConvertFileType.IE: 
            oPrintJob = new IEPrintJob(); 
            break;
        case convert2pdf.ConvertFileType.Publisher: 
            oPrintJob = new PublisherPrintJob(); 
            break;
        case convert2pdf.ConvertFileType.Visio: 
            oPrintJob = new VisioPrintJob(); 
            break;
        default: 
            oPrintJob = new GenericPrintJob();
            break;
    }
