    Public Class MyApplication
        Private _AppTimer As Timers.Timer
    
        Public Sub New()
            _AppTimer = New Timers.Timer()
            _AppTimer.Interval = 1 * 60 * 60 * 1000 '1 Hour * 60 Min * 60 Sec * 1000 Milli
    
            AddHandler _AppTimer.Elapsed, AddressOf AppTimer_Elapsed
    
            _AppTimer.Start()
        End Sub
    
        Private Sub AppTimer_Elapsed(s As Object, e As Timers.ElapsedEventArgs)
            Application.Restart()
        End Sub
    End Class
