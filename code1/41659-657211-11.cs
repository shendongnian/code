    range = sheet.Cells.Find("Value to Find",
                                                     Type.Missing,
                                                     Type.Missing,
                                                     Type.Missing,
                                                     Type.Missing,
                                                     Excel.XlSearchDirection.xlNext,
                                                     Type.Missing,
                                                     Type.Missing, Type.Missing);
    range.Text; //give you the value found
