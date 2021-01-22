      Private Sub Form_Main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
          Case Keys.Z
            If e.Modifiers = Keys.Control + Keys.Shift Then
              diagram.UndoManager.Redo()
            ElseIf e.Modifiers = Keys.Control Then
              diagram.UndoManager.Undo()
            End If
        End Select
      End Sub
