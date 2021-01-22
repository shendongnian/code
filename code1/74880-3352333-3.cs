    Private Sub CleanOutViewer()
        If Not Me.CrystalReportViewer1.ReportSource() Is Nothing Then
            CType(Me.CrystalReportViewer1.ReportSource(), CrystalDecisions.CrystalReports.Engine.ReportDocument).Close()
            CType(Me.CrystalReportViewer1.ReportSource(), CrystalDecisions.CrystalReports.Engine.ReportDocument).Dispose()
            Me.CrystalReportViewer1.ReportSource() = Nothing
            GC.Collect()
        End If
    End Sub
