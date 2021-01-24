    Word.Range rngSel = app.Selection.Range;
    bm = doc.Bookmarks.Add("bookmark", rngSel);
    Word.Range rngCC = rngSel.Duplicate;
    //Insert the content control immediately after the selection, for example
    rngCC.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
    ContentControl cc = doc.ContentControls.Add(WdContentControlType.wdContentControlRichText, rngCC);
    cc.MultiLine = true;
    cc.Tag = _BOOKMARK;
    cc.Range.FormattedText = rngSel.FormattedText;
    RngSel.Delete();
