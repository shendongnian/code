    Shared Sub Main(args as string[])
      If (Environment.UserInteractive = True) Then
        'Starts this up as an application.
        If (args.Length > 0 AndAlso args[0].Equals("-c")) Then 'usually a "DeriveCommand" function that returns an enum or something similar
          Dim isRunning As Boolean = true
          Dim _service As New DispatchService()
          _service.ServiceStartupMethod(Nothing)
          Console.WriteLine("Press ESC to stop running")
          While (IsRunning)
            While (Not (Console.KeyAvailable AndAlso (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape) OrElse Console.ReadKey(true).Key.Equals(ConsoleKey.R))))
               Thread.Sleep(1)
             End While                        
             Console.WriteLine()
             Console.WriteLine("Press ESC to continue running or any other key to continue shutdown.")
             Dim key = Console.ReadKey();
             if (key.Key.Equals(ConsoleKey.Escape))
             {
               Console.WriteLine("Press ESC to load shutdown menu.")
               Continue
             }
             isRunning = false
          End While
          _service.ServiceStopMethod()
        Else
          Throw New ArgumentException("Dont be a double clicker, this needs a console for reporting info and errors")
        End If
      Else
        'Runs as a service. '
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New DispatchService}
        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
      End If
    End Sub
