    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'simulate a long running task
        For x As Long = 1 To Long.MaxValue - 1
            'the absence of Application.DoEvents() is poor design IMHO
        Next
    End Sub
