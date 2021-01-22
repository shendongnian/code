    Private Sub CreateCSVFile(ByVal dt As DataTable, ByVal strFilePath As String)
        Using sw As New StreamWriter(strFilePath)
            CreateCSVFile(dt, sw)
        End Using
    End Sub
    Private Sub CreateCSVFile(ByVal dt As DataTable, ByVal outStream As TextWriter)
        ''# First we will write the headers. 
        ''EDataTable dt = m_dsProducts.Tables[0]; 
        Dim iColCount As Integer = dt.Columns.Count
        For i As Integer = 0 To iColCount - 1
            outStream.Write(dt.Columns(i))
            If i < iColCount - 1 Then
                outStream.Write(",")
            End If
        Next
        outStream.Write(sw.NewLine)
        ''# Now write all the rows. 
        For Each dr As DataRow In dt.Rows
            For i As Integer = 0 To iColCount - 1
                If Not Convert.IsDBNull(dr(i)) Then
                    outStream.Write(dr(i).ToString())
                End If
                If i < iColCount - 1 Then
                    outStream.Write(",")
                End If
            Next
            outStream.Write(outStream.NewLine)
        Next
    End Sub
