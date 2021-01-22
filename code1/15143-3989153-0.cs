      '----------------------------------------------------------------------------
      ' GetSchema
      '----------------------------------------------------------------------------
      Public Function GetSchema() As System.Xml.Schema.XmlSchema Implements System.Xml.Serialization.IXmlSerializable.GetSchema
        Return Nothing
      End Function
    
      '----------------------------------------------------------------------------
      ' ReadXml
      '----------------------------------------------------------------------------
      Public Sub ReadXml(ByVal reader As System.Xml.XmlReader) Implements System.Xml.Serialization.IXmlSerializable.ReadXml
        If (Not reader.IsEmptyElement) Then
          If (reader.Read AndAlso reader.NodeType = System.Xml.XmlNodeType.Text) Then
             Me._value = reader.ReadContentAs(GetType(T), Nothing)
          End If
        End If
      End Sub
    
      '----------------------------------------------------------------------------
      ' WriteXml
      '----------------------------------------------------------------------------
      Public Sub WriteXml(ByVal writer As System.Xml.XmlWriter) Implements System.Xml.Serialization.IXmlSerializable.WriteXml
        If (_hasValue) Then
          writer.WriteValue(Me.Value)
        End If
      End Sub
