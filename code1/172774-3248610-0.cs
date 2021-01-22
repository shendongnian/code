    Public Class ContextMenuManager
        Public Event Click As EventHandler
        Private WithEvents _myToolstripMenuItem As ToolStripMenuItem
    
        Public Sub New()
            ''...
        End Sub
    
        Private Sub _myToolstripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _myToolstripMenuItem.Click
            RaiseEvent Click(Me, e)
        End Sub
    End Class
