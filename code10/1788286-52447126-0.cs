    var para = textRange.Paragraphs.Add();
    var rng = para.Range;
    Clipboard.SetData(System.Windows.DataFormats.Rtf, text);
    rng.PasteSpecial(DataType: Microsoft.Office.Interop.Word.WdPasteDataType.wdPasteRTF);
    rng.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
    //Alternative to insert a new paragraph
    rng.Text = "\n";
    //prepare for the next entry, for illustration - of course you'd built this into a loop
    rng.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
    Clipboard.SetData(System.Windows.DataFormats.Rtf, otherText);
    rng.PasteSpecial(DataType: Microsoft.Office.Interop.Word.WdPasteDataType.wdPasteRTF);
