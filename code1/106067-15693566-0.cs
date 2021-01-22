    Public Class DynamicToolStripMenuItem
        Inherits ToolStripMenuItem
        Public Sub New(value As Integer, text As String, handler As System.EventHandler)
            MyBase.New()
            Me.Text = text
            Me.Visible = True
            Me.Tag = value
            AddHandler Me.Click, handler
        End Sub
    End Class
