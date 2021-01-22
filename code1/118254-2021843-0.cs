    Public Sub ExcelExport(ByVal objDataSet As System.Data.DataSet)
    
            Try
                Dim l_ofd As New SaveFileDialog
    
                l_ofd.Filter = "Microsoft 2007 Excel File (*.xls)|*.xls"
    
                If (l_ofd.ShowDialog = System.Windows.Forms.DialogResult.OK) Then
                    If (objDataSet.Tables.Count > 0) Then
    
                        Dim myExcel As ApplicationClass = New ApplicationClass()
    
                        myExcel.Visible = _ShowWorkBook
    
                        Dim wb1 As Workbook = myExcel.Workbooks.Add("")
    
                        Dim ws1 As Worksheet = CType(wb1.Worksheets.Add, Microsoft.Office.Interop.Excel.Worksheet)
    
                        ws1.Name = _WorkSheetName
    
                        For indx As Integer = 0 To objDataSet.Tables(_DataSetName).Columns.Count - 1
                            ws1.Cells(1, indx + 1) = objDataSet.Tables(_DataSetName).Columns.Item(indx).ToString
                        Next
    
                        Dim rowID As Integer = 2
                        Dim dr As DataRow
                        For Each dr In objDataSet.Tables(_DataSetName).Rows
                            Dim colID As Integer = 1
                            Dim data As Object
                            For Each data In dr.ItemArray
                                ws1.Cells(rowID, colID) = data.ToString()
                                colID += 1
                            Next
                            rowID += 1
                        Next
    
                        Dim fileName As String = l_ofd.FileName
    
                        wb1.SaveAs(fileName)
                        wb1.Close()
    
                        myExcel.Workbooks.Close()
                        myExcel.Quit()
    
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(myExcel)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(ws1)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(wb1)
    
                        ws1 = Nothing
                        wb1 = Nothing
                        myExcel = Nothing
                    Else
                        MessageBox.Show("No data present to export")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            End Try
    
        End Sub
