        private static EventWaitHandle _waitHandle;
        private static Service1 _service;
                static void Main(string[] args)
        {
            bool runConsole = false;**
            foreach (string arg in args)
            {
                if (arg.ToLowerInvariant().Equals("-console"))
                {
                    runConsole = true;
                }
            }   
            _service = new Service1();
            if (runConsole)
            {
                _waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
                Console.WriteLine("Starting Workflow Service in Console Mode");
                Console.WriteLine("Press Ctrl+C to exit Console Mode");
               Console.CancelKeyPress += new ConsoleCancelEventHandler(OnCancelKeyPress);
                _service.InternalStart();
                WaitHandle.WaitAll(new WaitHandle[] { _waitHandle });
            }
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new Service1() 
			};
            ServiceBase.Run(ServicesToRun);
        }
        static void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            _service.InternalStop();
            _waitHandle.Set();
        }
    }
