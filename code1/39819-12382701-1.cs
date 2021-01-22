    Dim client As Service.PersonServiceClient = New Service.PersonServiceClient()
    'Calls the SetSessionVariable() and store values in the session.
    client.SetSessionVariableAsync("Soumya")
    
    We will get the session variable in the .xaml page by calling GetSessionVariable() where we want to check the session
     
    Dim client As Service.PersonServiceClient = New Service.PersonServiceClient()
    AddHandler client.GetSessionVariableCompleted, AddressOf client_GetSessionVariableCompleted
    client.GetSessionVariableAsync()
     
    Private Sub client_GetSessionVariableCompleted(ByVal sender As Object, ByVal e As GetSessionVariableCompletedEventArgs)
            Try
                If Not String.IsNullOrEmpty(e.Result) Then
                    MessageBox.Show(e.Result)
                Else
                    MessageBox.Show("Your session has been expired")
                End If
            Catch ex As FaultException        
            End Try
    End Sub
