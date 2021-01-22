     MDbgEngine mg;
     try
     {
           mg = new MDbgEngine();
           mg.Attach(debugProcess.Id);
     }
     catch (Exception ed)
     {
           Console.WriteLine("Exception attaching to process " + debugProcess.Id );
           throw (ed);
     }
     foreach (MDbgProcess p in mg.Processes)
     {
         p.CorProcess.EnableLogMessages(true);
         p.CorProcess.OnLogMessage += new LogMessageEventHandler( HandleLogMessage );
      }
      mg.Options.StopOnLogMessage = true;
      mg.Processes.Active.Go().WaitOne();
      bool running=false;
      while (running)
        {
           try
           {
              running = mg.Processes.Active.IsAlive;
              mg.Processes.Active.Go().WaitOne();
            }
              catch
              {
                    running = false;
               }
           }
        }
