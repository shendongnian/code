        Public Class SerialisableClass
    
        Public Sub SaveToXML(ByVal outputFilename As String)
    
            Dim xmls = New System.Xml.Serialization.XmlSerializer(Me.GetType)
            Using sw = New IO.StreamWriter(outputFilename)
                xmls.Serialize(sw, Me)
            End Using
    
        End Sub
    
        Private tempState As Object = Me
        Public Sub ReadFromXML(ByVal inputFilename As String)
    
            Dim xmls = New System.Xml.Serialization.XmlSerializer(Me.GetType)
    
            Using sr As New IO.StreamReader(inputFilename)
                tempState = xmls.Deserialize(sr)
            End Using
    
            For Each pi In tempState.GetType.GetProperties()
    
                Dim name = pi.Name
    
                Dim realProp = (From p In Me.GetType.GetProperties
                                Where p.Name = name And p.MemberType = Reflection.MemberTypes.Property).Take(1)(0)
    
                realProp.SetValue(Me, pi.GetValue(tempState, Nothing), Nothing)
    
            Next
    
        End Sub
    
    End Class
