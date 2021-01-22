    Public Class Tree
      Private Level As Integer
      Public Sub New(Text As String, LevelIndicator As String)
        Me.New(Text, LevelIndicator, 0)
      End Sub
      Public Sub New(Text As String, LevelIndicator As String, StartingIndex As Integer)
        Me.Load(Text, LevelIndicator, StartingIndex)
      End Sub
      Public ReadOnly Property Nodes As List(Of Node)
        Get
          Return _Nodes
        End Get
      End Property
      Private ReadOnly _Nodes As New List(Of Node)
      Private Sub Load(Text As String, LevelIndicator As String, StartingIndex As Integer)
        Dim iLevel As Integer
        Dim oParents As Stack(Of Node)
        Dim oNode As Node
        oParents = New Stack(Of Node)
        Text.ToLines(StartingIndex).ForEach(Sub(Line As String)
                                              oNode = New Node(Line, LevelIndicator)
                                              If oNode.Level = 0 Then ' Root '
                                                Me.Nodes.Add(oNode)
                                                oParents.Push(oNode)
                                                Me.Level = 0
                                              ElseIf oNode.Level - Me.Level > 1 Then ' Skipped generation(s) '
                                                Throw New FormatException("The outline structure is invalid.")
                                              ElseIf oNode.Level = Me.Level Then ' Sibling '
                                                oParents.Pop()
                                                Me.Level = oParents.SetNode(oNode, Me.Level)
                                              ElseIf oNode.Level - Me.Level = 1 Then ' Child '
                                                Me.Level = oParents.SetNode(oNode, Me.Level + 1)
                                              ElseIf oNode.Level < Me.Level Then ' Walk back up the stack '
                                                For iLevel = 0 To Me.Level - oNode.Level
                                                  oParents.Pop()
                                                Next
                                                Me.Level = oParents.SetNode(oNode, oNode.Level)
                                              End If
                                            End Sub)
      End Sub
    End Class
