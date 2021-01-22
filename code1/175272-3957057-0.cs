    If System.Diagnostics.Debugger.IsAttached then
           Me.Text = "Debug Mode"
    Else 
           Me.Text = "Version " & My.Application.Deployment.CurrentVersion.ToString
    End If
