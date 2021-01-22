    Private Sub PipeXMLIntoWriter(xw As XmlWriter, xml As String)
        Dim dat As Byte() = New System.Text.UTF8Encoding().GetBytes(xml)
        Dim m As New MemoryStream()
        m.Write(dat, 0, dat.Length)
        m.Seek(0, SeekOrigin.Begin)
        Dim settings As New XmlReaderSettings
        settings.IgnoreWhitespace = True
        settings.IgnoreComments = True
        Dim r As XmlReader = XmlReader.Create(m, settings)
        While r.Read()
              Select Case r.NodeType
                    Case XmlNodeType.Element
                        xw.WriteStartElement(r.Name)
                        If r.HasAttributes Then
                            For i As Integer = 0 To r.AttributeCount - 1
                                r.MoveToAttribute(i)
                                xw.WriteAttributeString(r.Name, r.Value)
                            Next
                            r.MoveToElement()
                        End If
                        If r.IsEmptyElement Then
                            xw.WriteEndElement()
                        End If
                        Exit Select
                    Case XmlNodeType.EndElement
                        xw.WriteEndElement()
                        Exit Select
                    Case XmlNodeType.Text
                        xw.WriteString(r.Value)
                        Exit Select
                    Case Else
                        Throw New Exception("Unrecognized node type: " + r.NodeType)
                End Select
          End While
    End Sub
