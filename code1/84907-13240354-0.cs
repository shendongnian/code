    Private _syncContext As SynchronizationContext
    Private mBigStream As Stream
     Private Sub btnSave_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles btnSave.Click
        Try
            Dim saveDialog As New SaveFileDialog
            saveDialog.Filter = "Word |*.doc"
            saveDialog.DefaultExt = ".doc"
            If saveDialog.ShowDialog() Then
                Try
                    mBigStream = saveDialog.OpenFile()
                    _syncContext = SynchronizationContext.Current
                    oWebService.GetReportAsync(Params, ... , _syncContext)
                Catch ex As Exception
                    MessageBox.Show("File busy.")
                End Try
            End If
        Catch ex As Exception
            LogError((New System.Diagnostics.StackTrace()).GetFrame(0).GetMethod().Name.ToString, Err.Description)
        End Try
    End Sub
    Private Sub oWebService_GetReportCompleted(sender As Object, e As MainReference.GetReportCompletedEventArgs) Handles oWebService.GetReportCompleted
        Try
            ' e.Result is byte()
            If e.Result IsNot Nothing Then
                If e.Result.Count > 0 Then
                    _syncContext.Post(Sub()
                                          Try
                                              mBigStream.Write(e.Result, 0, e.Result.Length)
                                              mBigStream.Flush()
                                              mBigStream.Close()
                                              mBigStream.Dispose()
                                              mBigStream = Nothing
                                          Catch ex As Exception
                                              LogError((New System.Diagnostics.StackTrace()).GetFrame(0).GetMethod().Name.ToString, Err.Description)
                                          End Try
                                      End Sub, Nothing)
                    _syncContext = Nothing
                End If
            End If
        Catch ex As Exception
            LogError((New System.Diagnostics.StackTrace()).GetFrame(0).GetMethod().Name.ToString, Err.Description)
        End Try
    End Sub
