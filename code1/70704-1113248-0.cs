    private List<Image> _pages = new List<Image>();
    private int pageIndex = 0;
    
    private void PrintImage()
    {
        Image source = new Bitmap(@"C:\path\file.jpg");
        // split the image into 3 separate images
        _pages.AddRange(SplitImage(source, 3)); 
        
        PrintDocument printDocument = new PrintDocument();
        printDocument.PrintPage += PrintDocument_PrintPage;
        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        previewDialog.Document = printDocument;
        pageIndex = 0;
        previewDialog.ShowDialog();
        // don't forget to detach the event handler when you are done
        printDocument.PrintPage -= PrintDocument_PrintPage;
    }
    
    private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        // Draw the image for the current page index
        e.Graphics.DrawImageUnscaled(_pages[pageIndex], 
                                     e.PageBounds.X, 
                                     e.PageBounds.Y);
        // increment page index
        pageIndex++; 
        // indicate whether there are more pages or not
        e.HasMorePages = (pageIndex < _pages.Count);   
    }
