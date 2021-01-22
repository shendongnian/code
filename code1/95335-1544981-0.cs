    Using MyReader As New _
    Microsoft.VisualBasic.FileIO.TextFieldParser("C:\testfile.txt")
       MyReader.TextFieldType = FileIO.FieldType.Delimited
       MyReader.SetDelimiters(",")
       Dim currentRow As String()
       While Not MyReader.EndOfData
          Try
             currentRow = MyReader.ReadFields()
             Dim currentField As String
             For Each currentField In currentRow
                MsgBox(currentField)
             Next
          Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
          MsgBox("Line " & ex.Message & _
          "is not valid and will be skipped.")
          End Try
       End While
    End Using
