    Public Class UserControl2
    
        Private Sub tsMainMenu_BeginDrag(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsMainMenu.BeginDrag
    
            tsMainMenu.Tag = tsMainMenu.Parent
    
        End Sub
    
        Private Sub ToolStrip1_EndDrag(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMainMenu.EndDrag
    
    
            If Not tsMainMenu.Parent.Parent.Equals(CType(tsMainMenu.Tag, ToolStripPanel).Parent) Then
    
                CType(ToolStrip1.Tag, ToolStripPanel).Controls.Add(tsMainMenu)
            End If
    
        End Sub
    
    End Class
