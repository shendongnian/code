    int i = (int)range.get_Information(WdInformation.wdActiveEndPageNumber) % 2;
    WdHeaderFooterIndex index;
    if (i == 0 && range.Sections[1].PageSetup.OddAndEvenPagesHeaderFooter == 1)
    	index = WdHeaderFooterIndex.wdHeaderFooterEvenPages;
    else
    	index = WdHeaderFooterIndex.wdHeaderFooterPrimary;
    
    Range sRange = range.Sections[1].Range;
    object direction = Word.WdCollapseDirection.wdCollapseStart;
    sRange.Collapse(ref direction);
    if (range.get_Information(WdInformation.wdActiveEndPageNumber) == sRange.get_Information(WdInformation.wdActiveEndPageNumber)
    	&& range.Sections[1].PageSetup.DifferentFirstPageHeaderFooter == 1)
    	index = WdHeaderFooterIndex.wdHeaderFooterFirstPage;
    
    object rangeIndex = 1;
    Range headerRange = range.Sections[1].Headers[index].Range.ShapeRange.TextFrame.TextRange;
    
    string profession = headerRange.Tables[1].Cell(4, 1).Range.Text;
    string manPower = headerRange.Tables[1].Cell(4, 2).Range.Text;
    string registration = headerRange.Tables[1].Cell(4, 3).Range.Text;
    string taggingListNum = headerRange.Tables[1].Cell(4, 4).Range.Text;
