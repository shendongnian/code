        Public Function GetColumnList(DataSheetID As String) As List(Of String)
            Dim workingColumn As New BaseNumber("A")
            workingColumn.SetCharacterArray("@ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            Dim listOfPopulatedColumns As New List(Of String)
            Dim countOfEmptyColumns As Integer
            Dim colHasData As Boolean
            Dim cellHasData As Boolean
            Do
                colHasData = True
                cellHasData = False
                For r As Integer = 1 To GetMaxRow(DataSheetID)
                    cellHasData = cellHasData Or XLGetCellValue(DataSheetID, workingColumn.GetBaseXNumber & r) <> ""
                Next
                colHasData = colHasData And cellHasData
                'keep trying until we get 4 empty columns in a row
                If colHasData Then
                    listOfPopulatedColumns.Add(workingColumn.GetBaseXNumber)
                    countOfEmptyColumns = 0
                Else
                    countOfEmptyColumns += 1
                End If
                'we are already starting with column A, so increment after we check column A
                Do
                    workingColumn.SetNumber(workingColumn.GetBase10Number + 1)
                Loop Until Not workingColumn.GetBaseXNumber.Contains("@")
            Loop Until countOfEmptyColumns > 3
            Return listOfPopulatedColumns
        End Function
