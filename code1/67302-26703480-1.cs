      Public Function ToDataTable(FileName As String, Optional Delimiter As String = ",") As DataTable
        ToDataTable = New DataTable
        Using TextFieldParser As New Microsoft.VisualBasic.FileIO.TextFieldParser(FileName) With
          {.HasFieldsEnclosedInQuotes = True, .TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited, .TrimWhiteSpace = True}
          With TextFieldParser
            .SetDelimiters({Delimiter})
            .ReadFields.ToList.Unique.ForEach(Sub(x) ToDataTable.Columns.Add(x))
            ToDataTable.Columns.Cast(Of DataColumn).ToList.ForEach(Sub(x) x.AllowDBNull = True)
            Do Until .EndOfData
              ToDataTable.Rows.Add(.ReadFields.Select(Function(x) Text.BlankToNothing(x)).ToArray)
            Loop
          End With
        End Using
      End Function
