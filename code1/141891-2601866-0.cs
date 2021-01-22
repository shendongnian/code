    Private Sub Workbook_BeforeClose(Cancel As Boolean)
        If Not Me.Saved Then
            NotSavedPrompt = Me.Name & " has not been saved. Would you like to save now?"
            SaveYesNo = MsgBox(NotSavedPrompt, vbQuestion + vbYesNoCancel)
            Select Case SaveYesNo
                Case vbYes
                    Me.Save
                Case vbNo
                    Me.Saved = True
                Case vbCancel
                    Cancel = True
                    Exit Sub
              End Select
        End If
        Call MyRoutine() //'this should be your sub that does what you want
    End Sub
