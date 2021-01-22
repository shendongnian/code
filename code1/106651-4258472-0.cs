    var dialog = new PrintDialog(); 
 
    if (dialog.ShowDialog() == true) 
    {
         System.Printing.PrintTicket pt = dialog.PrintTicket;
         pt.PageOrientation = System.Printing.PageOrientation.Landscape;
         dialog.PrintTicket = pt;
         // Print the element. 
         dialog.PrintVisual(ReportContentPresenter, "Report"); 
    } 
