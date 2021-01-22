    Private Sub _calendar_DisplayModeChanged(ByVal sender As System.Object, ByVal e As Microsoft.Windows.Controls.CalendarModeChangedEventArgs)
    
        If _calendar.DisplayMode = Microsoft.Windows.Controls.CalendarMode.Month Then
            _calendar.DisplayMode = Microsoft.Windows.Controls.CalendarMode.Year
        End If
    
    End Sub
    
