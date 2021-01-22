    Public Class Node
      Public Sub New(Line As String, LevelIndicator As String)
        _Level = Line.PrefixCount(LevelIndicator)
        _Text = Line.Replace(LevelIndicator, String.Empty)
      End Sub
      Public ReadOnly Property Nodes As List(Of Node)
        Get
          Return _Nodes
        End Get
      End Property
      Private ReadOnly _Nodes As New List(Of Node)
      Public ReadOnly Property Level As Integer
        Get
          Return _Level
        End Get
      End Property
      Private ReadOnly _Level As Integer
      Public ReadOnly Property Text As String
        Get
          Return _Text
        End Get
      End Property
      Private ReadOnly _Text As String
    End Class
