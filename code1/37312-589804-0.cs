    Try
      'Hit the webservice.
    Catch ex As WebException
      Dim r As HttpWebResponse = CType(ex.Response(), HttpWebResponse)
      Using sr As StreamReader = New StreamReader(r.GetResponseStream())
        Dim err As String = sr.ReadToEnd()
        'Log the error contained in the "err" variable.
      End Using
      Return Nothing
    Finally
      'Clean up  
    End Try
