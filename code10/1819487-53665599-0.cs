    // copy
    Range cells1 = (Range)worksheet1.Cells[2, 3];
    cells1.Copy();
    
    // Paste
    Range cells2= (Range)worksheet2.Cells[2, 3];
    cells2.PasteSpecial(XlPasteType.xlPasteFormats);
