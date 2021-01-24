    Sub Main()
        Dim cts As New CancellationTokenSource()
        Dim ct = cts.Token
        Dim t = Task.Factory.StartNew(AddressOf InfiniteLoop, ct, ct)
        Thread.Sleep(5000)
        Console.WriteLine("Task Status after 5000 [ms]: {0}", t.Status)
        Debug.Assert(t.Status = TaskStatus.Running)
        cts.Cancel()
        Try
            t.Wait()
        Catch ex As Exception
            Console.WriteLine("ERROR: {0}", ex.Message)
        End Try
        Console.WriteLine("Task Status after cancelling: {0}", t.Status)
        Console.WriteLine("Press enter to exit....")
        Console.ReadLine()
    End Sub
    Public Sub InfiniteLoop(ByVal ct As CancellationToken)
        While True
            ct.ThrowIfCancellationRequested()
        End While
    End Sub
