    Public Overrides Function ProcessMessage(ByVal envelope As SoapEnvelope) As SoapFilterResult
        ' Remove all WS-Addressing and WS-Security header info
        RemoveTag(envelope.DocumentElement, "wsa:Action")
        RemoveTag(envelope.DocumentElement, "wsa:MessageID")
        RemoveTag(envelope.DocumentElement, "wsa:To")
        Return SoapFilterResult.[Continue]
    End Function
    Private Sub RemoveTag(ByVal XE As System.Xml.XmlElement, ByVal TagName As String)
        For Each N As XmlNode In XE
            If N.ChildNodes.Count > 0 Then
                RemoveTag(N, TagName)
            End If
            If N.Name = TagName Then
                XE.RemoveChild(N)
            End If
        Next
    End Sub
