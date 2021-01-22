    Private Sub BindClients()
        
       okcl = 0
        sql = "Select * from Client Order By cname"        
        Dim dacli As New SqlClient.SqlDataAdapter
        Dim cmd As New SqlClient.SqlCommand()
        cmd.CommandText = sql
        cmd.CommandType = CommandType.Text
        dacli.SelectCommand = cmd
        dacli.SelectCommand.Connection = Me.sqlcn
        Dim dtcli As New DataTable
        dacli.Fill(dtcli)
        dacli.Fill(dataTableClients)
        lstboxc.DataSource = dataTableClients
        lstboxc.DisplayMember = "cname"
        lstboxc.ValueMember = "ccode"
        okcl = 1
        If dtcli.Rows.Count > 0 Then
            ccode = dtcli.Rows(0)("ccode")
            Call ClientDispData1()
        End If
    End Sub
   
    Private Sub FilterClients()        
        
        Dim query As EnumerableRowCollection(Of DataRow) = From dataTableClients In 
        dataTableClients.AsEnumerable() Where dataTableClients.Field(Of String) 
        ("cname").Contains(txtSearch.Text.Trim()) Order By dataTableClients.Field(Of 
        String)("cname") Select dataTableClients
        Dim dataView As DataView = query.AsDataView()
        lstboxc.DataSource = dataView
        lstboxc.DisplayMember = "cname"
        lstboxc.ValueMember = "ccode"
        okcl = 1
        If dataTableClients.Rows.Count > 0 Then
            ccode = dataTableClients.Rows(0)("ccode")
            Call ClientDispData1()
        End If
    End Sub
