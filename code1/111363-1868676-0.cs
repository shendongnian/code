    Dim Timer As System.Timers.Timer
    
    Protected Overrides Sub OnStart(ByVal args() As String)
        Timer = New System.Timers.Timer(60000)
        AddHandler Timer.Elapsed, AddressOf timer_Elapsed
        Timer.Start()
    End Sub
    Protected Overrides Sub OnStop()
        Timer2.Stop()
    End Sub
    Private Sub timer_Elapsed(ByVal pSender As Object, ByVal pargs As System.Timers.ElapsedEventArgs)
        'Ensure the tick happens in the middle of the minute
        If DateTime.Now.Second < 25 Then
            Timer.Interval = 65000
        ElseIf DateTime.Now.Second > 35 Then
            Timer.Interval = 55000
        ElseIf DateTime.Now.Second >= 25 And DateTime.Now.Second <= 35 Then
            Timer.Interval = 60000
        End If
        'Logic goes here
     End Sub
