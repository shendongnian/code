    Private Sub PrintTableOrView(ByVal table As DataTable, ByVal label As String)
        Dim sw As System.IO.StringWriter
        Dim output As String
    
        Console.WriteLine(label)
    
        ' Loop through each row in the table.
        For Each row As DataRow In table.Rows
            sw = New System.IO.StringWriter
            ' Loop through each column.
            For Each col As DataColumn In table.Columns
                ' Output the value of each column's data.
                sw.Write(row(col).ToString() & ", ")
            Next
            output = sw.ToString
            ' Trim off the trailing ", ", so the output looks correct.
            If output.Length > 2 Then
                output = output.Substring(0, output.Length - 2)
            End If
            ' Display the row in the console window.
            Console.WriteLine(output)
        Next
        Console.WriteLine()
    End Sub
