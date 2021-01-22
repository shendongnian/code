    Imports System
    Imports System.IO
    Imports System.Runtime.Serialization
    Imports System.Xml
    Imports System.Xml.Schema
    Imports System.Xml.Serialization
    Imports System.ComponentModel
    
    Public Class CDataWrapper
        Implements IXmlSerializable
    
        'underlying value
        Public Property Value As String
    
        'Implicit to/from string
        Public Shared Widening Operator CType(ByVal value As CDataWrapper) As String
            If value Is Nothing Then
                Return Nothing
            Else
                Return value.Value
            End If
        End Operator
    
        Public Shared Widening Operator CType(value As String) As CDataWrapper
            If value Is Nothing Then
                Return Nothing
            Else
                Return New CDataWrapper() With {.Value = value}
            End If
        End Operator
    
    
        Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
            Return Nothing
        End Function
    
        ' <Node/> => ""
        ' <Node></Node> => ""
        ' <Node>Foo</Node> => "Foo"
        ' <Node><![CDATA[Foo]]></Node> => "Foo"
        Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
            If reader.IsEmptyElement Then
                Me.Value = ""
            Else
                reader.Read()
    
                Select Case reader.NodeType
                    Case XmlNodeType.EndElement
                        Me.Value = "" ' empty after all...
                    Case XmlNodeType.Text, XmlNodeType.CDATA
                        Me.Value = reader.ReadContentAsString()
                    Case Else
                        Throw New InvalidOperationException("Expected text/cdata")
                End Select
            End If
        End Sub
    
        ' "" => <Node/>
        ' "Foo" => <Node><![CDATA[Foo]]></Node>
        Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
            If Not String.IsNullOrEmpty(Me.Value) Then
                writer.WriteCData(Me.Value)
            End If
        End Sub
    
        Public Overrides Function ToString() As String
            Return Me.Value
        End Function
    End Class
