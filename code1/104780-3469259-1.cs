    Private bClosingForm As Boolean = False
    Private Sub SomeFormName_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        bClosingForm = True
        BackgroundWorker1.CancelAsync() 
    End Sub
    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'Run background tasks:
        If BackgroundWorker1.CancellationPending Then
            e.Cancel = True
        Else
            'Background work here
        End If
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
    
        If Not e.Cancelled And bClosingForm = True Then
            'Completion Work here
        End If
    End Sub
