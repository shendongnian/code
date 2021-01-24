        if (file.EndsWith(".xlsx")||file.EndsWith(".xls"))
        {
            book = application.Workbooks.Open(file);
            sheet = (Worksheet)book.Worksheets[1];
            range = sheet.get_Range("A1", "A1".ToString());
            range.EntireRow.Delete(XlDirection.xlUp);
            sheet.Cells[1, 2].EntireColumn.NumberFormat = "@";
            book.SaveAs(csvConverstion, XlFileFormat.xlCSV);
            book.Close(false, Type.Missing, Type.Missing);
            application.Quit();
        }
        else
        {
            MessageBox.Show("Incorrect file format.  Please save file in an .xls format");
        }
