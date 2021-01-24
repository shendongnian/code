    public StackPanel AddNewPage()
    {
        PageContent pC = new PageContent();
        FixedPage fP = new FixedPage { Width = PageWidth, Height = PageHeight, Margin = Margin };
        StackPanel sP = new StackPanel { Width = PageWidth - Margin.Left - Margin.Right };
        fP.Children.Add(sP);
        pC.Child = fP;
        //FixedDocument
        Document.Pages.Add(pC);
        //used later to add content to the page 
        return sP;
    }
    public bool IsPageOverfilled(int pageIndex)
    {
        StackPanel sP = (Document.Pages[pageIndex].Child as FixedPage).Children[0] as StackPanel;
        //necessary to recognize new added elements
        sP.UpdateLayout();
        sP.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        if (sP.DesiredSize.Height > MaxPageContentHeight)
            return true;
        else return false;
    }
