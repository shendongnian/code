    Range cellA1 = wSheet.get_Range("A1", System.Type.Missing);
    cellA1.Value2 = "0";
    cellA1.Copy(System.Type.Missing);
    Range cellAll = wSheet.get_Range("A1:AZ500", System.Type.Missing);
    cellAll.PasteSpecial(XlPasteType.xlPasteAll, XlPasteSpecialOperation.xlPasteSpecialOperationAdd,
            false, false);
