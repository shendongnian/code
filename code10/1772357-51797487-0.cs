    Microsoft.Office.Interop.Excel.Range source = existingSheet.Cells[5, 4];
    source.Copy(); // Copy everything from the source cell to the clipboard
    Microsoft.Office.Interop.Excel.Range target = newSheet.Cells[6, 3];
    target.Value = 456; // Write value to the target cell and ...
    target.PasteSpecial(XlPasteType.xlPasteFormats); // Paste only formats from the source cell
