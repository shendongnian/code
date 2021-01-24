    void SaveCanvasToPDF(Canvas myCanvas){
        PrintDialog pd = new PrintDialog();
        pd.PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF");
        pd.PrintTicket.PageOrientation = PageOrientation.Landscape;
        pd.PrintTicket.PageScalingFactor = 100;
        pd.PrintVisual(myCanvas, "Nomograph");
    }
