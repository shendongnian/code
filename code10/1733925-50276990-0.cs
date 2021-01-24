    Word.HeaderFooter hdr = doc.Sections[1].Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
    hdr.Range.Delete();
    Word.HeaderFooter ftr = doc.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
    ftr.Range.Delete();
    doc.Styles[Word.WdBuiltinStyle.wdStyleNormal].Font.ColorIndex = Word.WdColorIndex.wdBlue;
    doc.Content.Font.ColorIndex = Word.WdColorIndex.wdDarkRed;
