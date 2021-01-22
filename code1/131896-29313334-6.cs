    Public Class Test
      Private ReadOnly Tree As Tree
      Public Sub New()
        Me.Tree = New Tree(Me.Text, "-", 1)
      End Sub
      Public Sub Render()
        Me.Render(Me.Tree.Nodes)
      End Sub
      Public Sub Render(Nodes As List(Of Node))
        Nodes.ForEach(Sub(Node As Node)
                        Console.WriteLine("{0}{1}", Space(Node.Level), Node.Text)
                        Me.Render(Node.Nodes)
                      End Sub)
      End Sub
      Private ReadOnly Property Text As String
        Get
          Return _
            "TEST DATA" & vbCrLf &
            "countries" & vbCrLf &
            "-france" & vbCrLf &
            "--paris" & vbCrLf &
            "--bordeaux" & vbCrLf &
            "-germany" & vbCrLf &
            "--hamburg" & vbCrLf &
            "--berlin" & vbCrLf &
            "--hannover" & vbCrLf &
            "--munich" & vbCrLf &
            "-italy" & vbCrLf &
            "subjects" & vbCrLf &
            "-math" & vbCrLf &
            "--algebra" & vbCrLf &
            "--calculus" & vbCrLf &
            "-science" & vbCrLf &
            "--chemistry" & vbCrLf &
            "--biology" & vbCrLf &
            "other" & vbCrLf &
            "-this" & vbCrLf &
            "-that"
        End Get
      End Property
    End Class
