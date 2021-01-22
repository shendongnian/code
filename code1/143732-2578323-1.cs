        public void RunConsole(string[] args)
        {
            OnStart(args);
            Console.WriteLine("Service running ... press <ENTER> to stop");
            //Console.ReadLine();
            while (true)
            { }
            OnStop();
        }
