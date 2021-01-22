    public void CreateMyWPFControlReport(MyWPFControlDataSource usefulData)
    {
      //Set up the WPF Control to be printed
      MyWPFControl controlToPrint;
      controlToPrint = new MyWPFControl();
      controlToPrint.DataContext = usefulData;
      FixedDocument fixedDoc = new FixedDocument();
      PageContent pageContent = new PageContent();
      FixedPage fixedPage = new FixedPage();
      //Create first page of document
      fixedPage.Children.Add(controlToPrint);
      ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);
      fixedDoc.Pages.Add(pageContent);
      //Create any other required pages here
      //View the document
      documentViewer1.Document = fixedDoc;
    }
