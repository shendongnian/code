        Public Sub SubreportProcessingEventHandler(ByVal sender As Object, _
                                                   ByVal e As SubreportProcessingEventArgs)
        Select Case e.ReportPath
            Case "subreport1"
                Dim tbl As DataTable = New DataTable("TableName")
                Dim Status As DataColumn = New DataColumn
                Status.DataType = System.Type.GetType("System.String")
                Status.ColumnName = "Status"
                tbl.Columns.Add(Status)
                Dim Account As DataColumn = New DataColumn
                Account.DataType = System.Type.GetType("System.String")
                Account.ColumnName = "Account"
                tbl.Columns.Add(Account)
                Dim rw As DataRow = tbl.NewRow()
                rw("Status") = core.GetStatus
                rw("Account") = core.Account
                tbl.Rows.Add(rw)
                e.DataSources.Add(New ReportDataSource("ReportDatasourceName", tbl))
            Case "subreport2"
                core.DAL.cnStr = My.Settings.cnStr
                core.DAL.LoadSchedule()
                e.DataSources.Add(New ReportDataSource("ScheduledTasks", _
                                                       My.Forms.Mother.DAL.dsSQLCfg.tSchedule))
            Case "subreport3"
                core.DAL.cnStr = My.Settings.cnStr
                Dim dt As DataTable = core.DAL.GetNodesForDateRange(DateAdd("d", _
                                                                              -1 * CInt(e.Parameters("NumberOfDays").Values(0)), _
                                                                              Today), _
                                                                      Now)
                e.DataSources.Add(New ReportDataSource("Summary", dt))
        End Select
    End Sub
