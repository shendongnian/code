     Microsoft.Office.Tools.Excel.NamedRange namedRange1 =
        this.Controls.AddNamedRange(this.Range["A1", "A5"],
        "namedRange1");
     Excel.Range Range1 = namedRange1.Find("Seashell", missing, missing,
        Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByColumns,
        Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext,
        false, false, missing);
