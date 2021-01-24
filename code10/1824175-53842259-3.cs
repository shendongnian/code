        public FileTimerWatcher(ILogger logger) : base(logger)
        {
            if (timer == null)
            {
                // Create a timer with a 1.5 second interval.
                // monitor the files after 1.5 seconds.
                timer = new Timer(delay);
                // Hook up the event handler for the Elapsed event.
                timer.Elapsed += new ElapsedEventHandler(ProcessFolder);
                
                timer.AutoReset = true;
                timer.Enabled = true;
            }
        }
        
        private void ProcessFolder(object sender, ElapsedEventArgs e)
        {
            var LastChecked = DateTime.Now;
            string[] files = System.IO.Directory.GetFiles(SourceDirectory, somefilter, System.IO.SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                ProcessFile(file); // process file here
            }
        }
