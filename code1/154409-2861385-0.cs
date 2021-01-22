            '''<summary>
        ''' Retrieved the data in spreadsheet to a ADO.net dataset. This should make things mega easy to work with. 
        ''' See Microsoft KB316934 for details on how this was done.
        ''' Optional First row = field titles method variable, which extends the options available to the calling application.
        '''</summary>
        '''<example>
        ''' When passing in the variable "SheetorNamedRangeorSheetNumber" please use the following examples.
        '''•	Use the sheet name followed by a dollar sign (for example, [Sheet1$] or [My Worksheet$]). A workbook table that is referenced in this manner includes the whole used range of the worksheet.
        '''Select * from [Sheet1$]
        '''•	Use a range with a defined name (for example, [MyNamedRange]):
        '''Select * from [MyNamedRange]
        '''•	Use a range with a specific address (for example, [Sheet1$A1:B10]):
        '''Select * from [Sheet1$A1:B10]
        '''</example>
        ''' <param name="filePath">The full path to the excel file. If you pass in a relative path, it will be automatically converted to a full path. The file has to exist for this method to return a dataset.  If the file doesn't exist a FileNotFoundException will be raised.</param>
        ''' <param name="firstRowTitles">Boolean to indicate if the first row of the spreadsheet contains column titles.</param>
        ''' <param name="readAsTextData">Boolean to indicate if the spreadsheet should be read as as text data.  This is particularly important for columns that may contain mixed numberic and alpha numeric data.  </param>
        ''' <remarks>
        ''' Its not possible to open and excel workbook via this method if there is password protection on the workbook.  It could be removed
        ''' by automation and then loaded or manaully removed before running this code.
        '''
        '''   LL: The IMEX=1 setting then references the values set in the Windows registry
        '''
        ''' Check the following registry settings for the *machine*:
        ''' Hkey_Local_Machine/Software/Microsoft/Jet/4.0/Engines/Excel/TypeGuessRows
        ''' Hkey_Local_Machine/Software/Microsoft/Jet/4.0/Engines/Excel/ImportMixedTypes
        ''' Hkey_Local_Machine/SOFTWARE/Wow6432Node/Microsoft/Jet/4.0/Engines/Excel
        ''' TypeGuessRows: setting the value to 0 (zero) will force ADO to scan
        ''' all column values before choosing the appropriate data type.
        ''' ImportMixedTypes: should be set to value 'Text' i.e. import mixed-type
        ''' columns as text:
        ''' Using IMEX=1 in the connection string (as you have done) ensures the
        ''' registry setting is applied.
        ''' Office 2007 data drivers can be downloaded free at <see>http://www.microsoft.com/downloads/details.aspx?familyid=7554F536-8C28-4598-9B72-EF94E038C891&amp;displaylang=en</see>
        ''' 
        ''' </remarks>
        Overloads Function GetDataSet(ByVal filePath As String, ByVal sheetOrNamedRangeOrSheetNumber As String, ByVal firstRowTitles As Boolean, ByVal readAsTextData As Boolean) As System.Data.DataSet
            Dim strConnectionString As String = String.Empty
            Dim connection As New System.Data.OleDb.OleDbConnection
            Dim cmd As New System.Data.OleDb.OleDbCommand
            Dim adp As New System.Data.OleDb.OleDbDataAdapter
            Dim dset As New System.Data.DataSet
            Dim strSheetName As String
            Dim ExcelFileInfo As System.IO.FileInfo
            '   Registry manipulation features.
            Dim currentJetRegistryValue As String = "19"
            '   Excel file extension handling
            Dim ExcelFileType As Excel.ExcelVersion = ExcelVersion.Unknown
            ExcelFileInfo = New System.IO.FileInfo(filePath)
            If ExcelFileInfo.Exists Then
                Select Case ExcelFileInfo.Extension.ToLower
                    Case ".xls"
                        ExcelFileType = ExcelVersion.Excel97_2003
                    Case ".xlsx"
                        ExcelFileType = ExcelVersion.Excel2007
                    Case Else
                        ExcelFileType = ExcelVersion.Unknown
                        Throw New ExcelException(-2, String.Format("Excel file extension '{0}' is not valid or code changes are required to handle that file extension.", ExcelFileInfo.Extension), "")
                End Select
               
                Try
                    Select Case ExcelFileType
                        Case ExcelVersion.Excel97_2003
                            '   Need to get the current registry setting, because we can change the value temporarily
                            currentJetRegistryValue = Me.GetJetExcelRegistry
                            If currentJetRegistryValue <> "0" Then
                                Me.UpdateJetExcelRegistry("0")
                            End If
                            If readAsTextData Then
                                If firstRowTitles Then
                                    strConnectionString = System.String.Format(My.Resources.ExcelConnectionWithHeaderAllText, ExcelFileInfo.FullName)
                                Else
                                    strConnectionString = System.String.Format(My.Resources.ExcelConnectionWithoutHeaderAllText, ExcelFileInfo.FullName)
                                End If
                            Else
                                If firstRowTitles Then
                                    strConnectionString = System.String.Format(My.Resources.ExcelConnectionWithHeader, ExcelFileInfo.FullName)
                                Else
                                    strConnectionString = System.String.Format(My.Resources.ExcelConnectionWithoutHeader, ExcelFileInfo.FullName)
                                End If
                            End If
                        Case ExcelVersion.Excel2007
                            '   Need to get the current registry setting, because we can change the value temporarily
                            currentJetRegistryValue = Me.GetExcel2007Registry
                            If currentJetRegistryValue <> "0" Then
                                Me.UpdateExcel2007Registry("0")
                            End If
                            If firstRowTitles Then
                                strConnectionString = System.String.Format(My.Resources.Excel2007ConnectionWithHeaderAllText, ExcelFileInfo.FullName)
                            Else
                                strConnectionString = System.String.Format(My.Resources.Excel2007ConnectionWithoutHeaderAllText, ExcelFileInfo.FullName)
                            End If
                    End Select
                    If strConnectionString = String.Empty Then
                        Throw New ExcelException(-3, "Excel Connection string hasn't been set.", "")
                    End If
                    connection = New System.Data.OleDb.OleDbConnection
                    With connection
                        .ConnectionString = strConnectionString
                        .Open()
                    End With
                    '   Create a command connection
                    cmd = New System.Data.OleDb.OleDbCommand
                    With cmd
                        .Connection = connection
                        .CommandType = CommandType.Text
                        If IsNumeric(sheetOrNamedRangeOrSheetNumber) = True Then
                            '   Ok extract the sheet name from the connection first
                            Dim objDT As New System.Data.DataTable
                            objDT = connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
                            strSheetName = objDT.Rows(CInt(sheetOrNamedRangeOrSheetNumber)).Item("TABLE_NAME").ToString
                            objDT = Nothing
                            .CommandText = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, My.Resources.ExcelSelectStatement, strSheetName)
                        Else
                            '   Must be a name, range or name Cell reference
                            .CommandText = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, My.Resources.ExcelSelectStatement, sheetOrNamedRangeOrSheetNumber)
                        End If
                        '.ExecuteReader()        'Forward only Dataset
                    End With
                    '   Create a data adapter to store the inforamtion
                    adp = New System.Data.OleDb.OleDbDataAdapter
                    dset = New DataSet
                    With adp
                        .SelectCommand = cmd
                        .Fill(dset, My.Resources.DataSetTableName)
                    End With
                    Select Case ExcelFileType
                        Case ExcelVersion.Excel97_2003
                            '   Restore the Excel readrows value, as we have finished with our modification.
                            If currentJetRegistryValue <> Me.GetJetExcelRegistry Then
                                '   Restore the registry setting (Securtiy implications)
                                Me.UpdateJetExcelRegistry(currentJetRegistryValue)
                            End If
                        Case ExcelVersion.Excel2007
                            '   Restore the Excel readrows value, as we have finished with our modification.
                            If currentJetRegistryValue <> Me.GetExcel2007Registry Then
                                '   Restore the registry setting (Securtiy implications)
                                Me.UpdateExcel2007Registry(currentJetRegistryValue)
                            End If
                    End Select
                    '   Return the resulting dataset to the calling application
                    GetDataSet = dset
                Catch comex As System.Runtime.InteropServices.COMException
                    Throw New ExcelException(comex.ErrorCode, comex.Message, comex.InnerException)
                Catch ex As System.InvalidOperationException
                    Throw New ExcelException(-1, ex.Message, ex.InnerException)
                Finally
                    If Not cmd Is Nothing Then cmd = Nothing
                    If Not connection Is Nothing Then
                        connection.Close()
                        connection.Dispose()
                        connection = Nothing
                    End If
                    If Not adp Is Nothing Then adp = Nothing
                    If Not dset Is Nothing Then dset = Nothing
                End Try
            Else
                Throw New System.IO.FileNotFoundException(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, My.Resources.FileNotFound, filePath))
                Return Nothing
            End If
        End Function
