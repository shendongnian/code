    Public Sub CommentSelection()
        If Not DTE.ActiveDocument.Selection.IsEmpty Then
            DTE.ActiveDocument.Selection.Text = "/* " + DTE.ActiveDocument.Selection.Text + " */"
        End If
    End Sub
