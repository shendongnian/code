    private async void btnPrint_Click(object sender, RoutedEventArgs e)
    {
        if (printDoc != null)
        {
            printDoc.GetPreviewPage -= OnGetPreviewPage;
            printDoc.Paginate -= PrintDic_Paginate;
            printDoc.AddPages -= PrintDic_AddPages;
        }
        this.printDoc = new PrintDocument();
        printDoc.GetPreviewPage += OnGetPreviewPage;
        printDoc.Paginate += PrintDic_Paginate;
        printDoc.AddPages += PrintDic_AddPages;
    
        PreparePrintContent(new PageToPrint());
    
        bool showPrint = await PrintManager.ShowPrintUIAsync();
    }
    
    private void PreparePrintContent(Page pageToPrint)
    {
        var canvas=(Canvas)this.FindName("MyCanvas");
        canvas.Children.Clear();
        canvas.Children.Add(pageToPrint);
    }
