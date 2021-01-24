    //load source document
    Document pdfDocument = new Document();
    //add a page
    pdfDocument.Pages.Add();
    //load source image
    ImageStamp imageStamp = new ImageStamp(dataDir + @"aspose-logo.jpg");
    imageStamp.Background = true;
    //set different values
    imageStamp.Height = 100;
    imageStamp.Width = 100;
    imageStamp.Opacity = 0.5;
            
    foreach (Page page in pdfDocument.Pages)
    {
        //assuming margins as zero
        page.PageInfo.Margin.Top = 0;
        page.PageInfo.Margin.Bottom = 0;
        page.PageInfo.Margin.Left = 0;
        page.PageInfo.Margin.Right = 0;
        for (double y = 0; y < page.PageInfo.Height; y = y + imageStamp.Height)
        {
            for (double x = 0; x < page.PageInfo.Width; x = x + imageStamp.Width)
            {
                imageStamp.XIndent = x;
                imageStamp.YIndent = y;
                page.AddStamp(imageStamp);
            }
        }
    }
    //save generated PDF document
    pdfDocument.Save( dataDir + @"New_18.5.pdf");
