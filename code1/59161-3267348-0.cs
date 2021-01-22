    Public Function GetSchema(ByVal dbNames As IEnumerable(Of String)) As DataTable
       Dim schemaTables As New List(Of DataTable)()
       For Each dbName As String In dbNames
          Dim cnnStr = GetConnectionString(dbName)
          Dim cnn As New SqlConnection(cnnStr)
          cnn.Open()
          Dim dt = cnn.GetSchema("Columns")
          cnn.Close()
          schemaTables.Add(dt)
       Next
    
       Dim dtResult As DataTable = Nothing
       For Each dt As DataTable In schemaTables
          If dtResult Is Nothing Then
             dtResult = dt
          Else
             dt.AsEnumerable().CopyToDataTable(dtResult, LoadOption.PreserveChanges)
          End If
       Next
    
       Return dtResult
    End Function
