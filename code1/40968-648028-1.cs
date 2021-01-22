    Private Sub foo()
        stpw.Reset() : stpw.Start()
        Do
        Loop While stpw.ElapsedMilliseconds < 1000
        stpw.Stop()
        Debug.WriteLine("foo")
    End Sub
    Dim stpw As New Stopwatch
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Debug.WriteLine("")
        Debug.WriteLine("but click")
        Dim t As New Threading.Thread(AddressOf foo)
        t.Start()
        Do
            Threading.Thread.Sleep(10)
            'Application.DoEvents() 'uncomment to change the behavior
        Loop While stpw.IsRunning
        Debug.WriteLine("but exit")
    End Sub
