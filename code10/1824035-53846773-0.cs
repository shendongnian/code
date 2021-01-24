    Word.Range ftr = null;
    Word.Paragraph para = null;
    Word.Range paraRng = null;
    Word.Range tStop1 = null;
    Word.Range tStop2 = null;
    int nrTabs;
    foreach (Word.Section sec in doc.Sections)
            {
        ftr = sec.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
        para = ftr.Paragraphs[1];
        nrTabs = para.TabStops.Count;
        if (nrTabs == 2)
        {
            paraRng = para.Range;
            tStop1 = paraRng.Duplicate;
            tStop1.Find.Execute("^t", missing, missing, missing, missing, missing,
                missing, missing, Word.WdFindWrap.wdFindStop);
            tStop1.MoveStart(Word.WdUnits.wdCharacter, 1); //put it after the tab character
            tStop2 = tStop1.Duplicate;
            tStop2.Find.Execute("^t", missing, missing, missing, missing, missing,
                missing, missing, Word.WdFindWrap.wdFindStop);
            tStop2.MoveEnd(Word.WdUnits.wdCharacter, -1); //put it before the tab character
            tStop1.End = tStop2.End;
            tStop1.Text = "Confidential";
            tStop1.Font.ColorIndex = Word.WdColorIndex.wdDarkRed;
            tStop1.Font.Size = 20f;
        }
    }
