    Try
        httpWebrequest.GetResponse()
    Catch we As WebException When we.Response IsNot Nothing _
                                  AndAlso TypeOf we.Response Is HttpWebResponse _
                                  AndAlso (DirectCast(we.Response, HttpWebResponse).StatusCode = HttpStatusCode.NotFound)
        
        ' ...
    
    End Try
