    var dlg = new PrintDialog();
        
    dlg.PrintQueue = printer; // this will be your printer. any of these: new PrintServer().GetPrintQueues()
    dlg.PrintTicket.CopyCount = 3; // number of copies
    dlg.PrintTicket.PageOrientation = PageOrientation.Landscape;
        
    dlg.PrintVisual(canvas);
