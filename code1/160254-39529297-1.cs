    Dim dt1 As New DataTable
    dt1 = dtExcelData.Clone()
    dt1.Columns(17).DataType = System.Type.GetType("System.Decimal")
    dt1.Columns(26).DataType = System.Type.GetType("System.Decimal")
    dt1.Columns(30).DataType = System.Type.GetType("System.Decimal")
    dt1.Columns(35).DataType = System.Type.GetType("System.Decimal")
    dt1.Columns(38).DataType = System.Type.GetType("System.Decimal")
    dt1 = dtprevious.Copy()
