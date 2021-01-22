    Public Function RunProcess(ByVal executableFileName As String, ByVal arguments As String, ByVal workingDirectory As System.String) As RunProcessResponse
        Dim process As System.Diagnostics.Process = Nothing
        Dim response As RunProcessResponse
    
        Try
            process = New System.Diagnostics.Process()
            Dim psInfo As New System.Diagnostics.ProcessStartInfo()
            Dim errorString As System.String = String.Empty
            Dim outputString As System.String = String.Empty
    
    
            If Not System.String.IsNullOrEmpty(workingDirectory) Then
                psInfo.WorkingDirectory = workingDirectory
            End If
    
            psInfo.FileName = executableFileName
            psInfo.Arguments = arguments
            psInfo.WindowStyle = ProcessWindowStyle.Hidden
            psInfo.CreateNoWindow = True
            psInfo.RedirectStandardError = True
            psInfo.RedirectStandardOutput = True
            psInfo.UseShellExecute = False
    
            AddHandler process.ErrorDataReceived, Sub(sender As Object, args As DataReceivedEventArgs)
                                                      If args.Data IsNot Nothing Then
                                                          errorString &= args.Data & vbCrLf
                                                      End If
                                                  End Sub
            AddHandler process.OutputDataReceived, Sub(sender As Object, args As DataReceivedEventArgs)
                                                       If args.Data IsNot Nothing Then
                                                           outputString &= args.Data & vbCrLf
                                                       End If
                                                   End Sub
    
            process.StartInfo = psInfo
            process.Start()
    
            process.BeginErrorReadLine()
            process.BeginOutputReadLine()
            process.WaitForExit()
    
            response = New RunProcessResponse(errorString, outputString, process.ExitCode)
    
            Return response
        Finally
            If process IsNot Nothing Then
                process.Dispose()
            End If
        End Try
    End Function
