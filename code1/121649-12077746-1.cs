    If e.Clicks = 2 Then
                doubleClickTimer.Stop()
            ElseIf e.Clicks = 1 Then
                doubleClickTimer.Enabled = True
                doubleClickTimer.Interval = 1000
                doubleClickTimer.Start()
    
    
            End If
    
    
     Private Sub doubleClickTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles doubleClickTimer.Tick
    
            OpenWebPage("abc")
            doubleClickTimer.Stop()
        End Sub
