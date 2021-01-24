    Word.Document currDocument = WordApp.ActiveDocument;
    Word.Selection currentSelection = WordApp.Selection;
    if(currentSelection.HeaderFooter.IsHeader)
    {
      Word.Range selectionRange = currentSelection.Range;
      selectionRange.Text ="abc";
      currentDocument.Bookmarks.Add("bookmark", selectionRange);
      //currentDocument.Bookmarks[bookmarkName].Select();
      Word.Range rngAfterBookmark = selectionRange.Duplicate;
      //go to the end of the bookmarked range
      rngAfterBookmark.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
      //make sure the two ranges are no longer adjacent
      rngAfterBookmark.Text = " ";
      rngAfterBookmark.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
      selectionRange.HighlightColorIndex = WdColorIndex.wdBrightGreen;
    } 
