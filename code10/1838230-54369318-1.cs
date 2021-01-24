    for (int i = 1; i <= workbook.Sheets.Count; i++)
    {
        sheet = (Worksheet)workbook.Sheets.get_Item(i);   
        if (sheet.ListObjects.Count > 0)
        {
           foreach (ListObject obj in sheet.ListObjects)
           {
              obj.QueryTable.Delete();
           }
        }
    }
