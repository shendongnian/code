    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ds As System.Data.DataSet = Me.GetMetrics()
        If ds IsNot Nothing Then
            For i As Integer = 0 To ds.Tables.Count - 1
                Dim _rpt As New System.Web.UI.WebControls.DataGrid()
                With _rpt
                    .AutoGenerateColumns = True
                    .Attributes.Add("name", "table_" & i + 1)
                    .DataSource = ds.Tables(i)
                    .DataBind()
                End With
                Me.phMetrics.Controls.Add(_rpt)
            Next
        End If
    End Sub
    Private Function GetMetrics() As System.Data.DataSet
        Dim dsMetrics As New System.Data.DataSet
        Using _sqlConn As New System.Data.SqlClient.SqlConnection(_sqlConnString)
            _sqlConn.Open()
            Dim _SqlCommand As New System.Data.SqlClient.SqlCommand("[dbo].[My_Stored_Procedure]", _sqlConn)
            With _SqlCommand
                .CommandType = System.Data.CommandType.StoredProcedure
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ClientID", 101))
            End With
            Dim _sqlAdapter As New System.Data.SqlClient.SqlDataAdapter(_SqlCommand)
            With _sqlAdapter
                .Fill(dsMetrics)
                .Dispose()
            End With
            _sqlConn.Close()
            _sqlConn.Dispose()
        End Using
        Return dsMetrics
    End Function
