    // Our custom Header and Footer is done using Event Handler
    TwoColumnHeaderFooter PageEventHandler = new TwoColumnHeaderFooter();
    PDFWriter.PageEvent = PageEventHandler;
    // Define the page header
    PageEventHandler.Title = Title;
    PageEventHandler.HeaderFont = FontFactory.GetFont(BaseFont.COURIER_BOLD, 10, Font.BOLD);
    PageEventHandler.HeaderLeft = "Group";
    PageEventHandler.HeaderRight = "1";
