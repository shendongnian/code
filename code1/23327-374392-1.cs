     MDbgEngine mg;
     MDbgProcess mgProcess;
     try
     {
           mg = new MDbgEngine();
           mgProcess = mg.Attach(debugProcess.Id);
     }
     catch (Exception ed)
     {
           Console.WriteLine("Exception attaching to process " + debugProcess.Id );
           throw (ed);
     }
     mgProcess.CorProcess.EnableLogMessages(true);
     mgProcess.CorProcess.OnLogMessage += new LogMessageEventHandler(HandleLogMessage);
     mg.Options.StopOnLogMessage = true;
     mgProcess.Go().WaitOne();
     bool running = true;
     Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
      while (running)
       {
           try
           {
               running =mgProcess.IsAlive;
               mgProcess.Go().WaitOne();
            }
            catch
             {
                running = false;
             }
         }
