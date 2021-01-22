    Private Shared Sub CopyElement(ByVal FromE As Xml.XmlElement, ByVal ToE As Xml.XmlElement)
        CopyElement(FromE, ToE, Nothing)
    End Sub
    Private Shared Sub CopyElement(ByVal FromE As Xml.XmlElement, ByVal ToE As Xml.XmlElement, ByVal overAttr As Xml.XmlAttributeCollection)
        Dim NewE As Xml.XmlElement
        Dim e As Xml.XmlElement
        NewE = ToE.OwnerDocument.CreateElement(FromE.Name)
        CopyAttributes(FromE, NewE)
        If Not overAttr Is Nothing Then
            OverrideAttributes(overAttr, NewE)
        End If
        For Each e In FromE
            CopyElement(e, NewE, overAttr)
        Next
        ToE.AppendChild(NewE)
    End Sub
    Private Shared Sub CopyAttributes(ByVal FromE As Xml.XmlElement, ByVal ToE As Xml.XmlElement)
        Dim a As Xml.XmlAttribute
        For Each a In FromE.Attributes
            ToE.SetAttribute(a.Name, a.Value)
        Next
    End Sub
    Private Shared Sub OverrideAttributes(ByVal AC As Xml.XmlAttributeCollection, ByVal E As Xml.XmlElement)
        Dim a As Xml.XmlAttribute
        For Each a In AC
            If Not E.Attributes.ItemOf(a.Name) Is Nothing Then
                E.SetAttribute(a.Name, a.Value)
            End If
        Next
    End Sub
