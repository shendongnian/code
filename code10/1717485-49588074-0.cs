    Dim client As HttpClient
    With client
        .BaseAddress = New Uri("Http://www.foo.foo")
        .DefaultRequestHeaders.Accept.Clear()
        .DefaultRequestHeaders.Accept.Add(New Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
        .DefaultRequestHeaders.Add("X-User", user)
    End With
    '...'
    Private Async Function PostAsync(Byval jsonString as String) As Task
        Dim content As New Net.Http.StringContent(jsonString, System.Text.Encoding.UTF8, "application/json")
        Dim response As Net.Http.HttpResponseMessage = Await client.PostAsync("", content)
        Dim result As String = Await response.Content.ReadAsStringAsync()
        
        'do something with the result.'
        
    End Function
    
