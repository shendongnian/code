           string id = "OZHAN1";
            
            Microsoft.Office.Interop.Excel.Range resultRange = excelRange.Find(
            What: id,
            LookIn: Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues,
            LookAt: Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
            SearchOrder: Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
            SearchDirection: Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext
            );
            string sAddress = resultRange.get_Address(false, false, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, false, false);
            string b= excelSheet.Cells[resultRange.Row, 5].VALUE;
