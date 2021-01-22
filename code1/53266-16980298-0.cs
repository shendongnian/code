    Public Function ToQueryString(nvc As System.Collections.Specialized.NameValueCollection) As String
        Dim lsParams As New List(Of String)()
    
        For Each strKey As String In nvc.AllKeys
            Dim astrValue As String() = nvc.GetValues(strKey)
    
            For Each strValue As String In astrValue
                lsParams.Add(String.Format("{0}={1}", System.Web.HttpUtility.UrlEncode(strKey), System.Web.HttpUtility.UrlEncode(strValue)))
            Next ' Next strValue
        Next ' strKey
        Dim astrParams As String() = lsParams.ToArray()
        lsParams.Clear()
        lsParams = Nothing
    
        Return "?" + String.Join("&", astrParams)
    End Function ' ToQueryString
