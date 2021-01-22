    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsRunAsAdministrator() Then
            Dim processInfo = New ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase)
            processInfo.UseShellExecute = True
            processInfo.Verb = "runas"
            Try
                Process.Start(processInfo)
            Catch ew1 As Exception
                MessageBox.Show("Sorry, this application must be run as Administrator.")
            End Try
            'Application.Current.Shutdown()
            Application.ExitThread()
        Else
       'your statement here
      End If
    End Sub
