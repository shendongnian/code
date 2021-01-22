    UInt32Value headerFontIndex =
                    createFont(
                        styleSheet,
                        "MS Sans Seif",
                        10,
                        true,
                        System.Drawing.Color.Black, false);
    
     UInt32Value doubleBorderIndex = createBorder(styleSheet, true);
    
                UInt32Value headerStyleIndexWithDoubleBottomBorder =
                   createCellFormat(
                       styleSheet,
                       headerFontIndex,
                       0,
                       null, doubleBorderIndex);
     Cell _Cell = createTextCell(1, 1, "Intercompany Reconciliation Summary", headerStyleIndexWithDoubleButtomBorder, null);
