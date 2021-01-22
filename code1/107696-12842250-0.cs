    'CORRECTED VERSION OF LAST FUNCTION ABOVE 
    
    Protected Overrides Function GetWebRequest(ByVal address As System.Uri) As System.Net.WebRequest
                Dim w As System.Net.WebRequest = MyBase.GetWebRequest(address)
                If _TimeoutMS <> 0 Then
                    w.Timeout = _TimeoutMS
                End If
                Return w  '<<< NOTICE: MyBase.GetWebRequest(address) DOES NOT WORK >>>
            End Function
