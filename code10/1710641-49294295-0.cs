    Dim parser As TextFieldParser = New TextFieldParser(diNext.FullName)
    parser.Delimiters = New String() {","}
    parser.HasFieldsEnclosedInQuotes = True
    While Not parser.EndOfData
        Try
           Dim fields As String() = parser.ReadFields()
           'Do my processing from here... yahoooo....
        Catch ex As Exception                                
           'Log problem                               
        End Try
    End While
