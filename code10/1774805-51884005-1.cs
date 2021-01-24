    var dlg = new PrintDialog();
    dlg.PageRangeSelection = PageRangeSelection.AllPages;
    dlg.UserPageRangeEnabled = false;
    if(dlg.ShowDialog() == true)
    {                
    	var doc = new FlowDocument();
    	// For normal A4&/letter pages, the defaults will print in two columns
    	doc.ColumnWidth = dlg.PrintableAreaWidth;
    	doc.Blocks.Add(new Paragraph(new Run("My arbitrary long string to print.\nNewlines work. Pages will break as needed.")));
    	dlg.PrintDocument(((IDocumentPaginatorSource)doc).DocumentPaginator, "Simple document");
    }
