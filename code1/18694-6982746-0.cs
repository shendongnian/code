    Private serviceController As ServiceController = Nothing 
    Private serviceControllerStatusRunning = False
    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            serviceController = New ServiceController("NameOfTheTheServiceYouWant")
            If serviceController.Status = ServiceControllerStatus.Stopped Then
                ' put code for stopped status here
            Else
                ' put code for running status here
            End If
            BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show("error:" + ex.Message)
            serviceController = Nothing
            Me.Close()
            Exit Sub
        End Try
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If serviceControllerStatusRunning Then
            serviceController.WaitForStatus(ServiceControllerStatus.Stopped)
            serviceControllerStatusRunning = False
        Else
            serviceController.WaitForStatus(ServiceControllerStatus.Running)
            serviceControllerStatusRunning = True
        End If
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
         if serviceControllerStatusRunning then
           ' put code for running status here
         else
           ' put code for stopped status here
         end if
         BackgroundWorker1.RunWorkerAsync() ' start worker thread again
    End Sub
