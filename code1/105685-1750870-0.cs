        [STAThread]
        static void Main()
        {
            SingleInstance single = new SingleInstance();
            if (single.FirstInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("SingleInstanceApp is already running");
            }
            
        }
        private class SingleInstance
        {
			private void SingleInstance()
			{
				try
				{
					//Grab mutex if it exists
					mutex = Mutex.OpenExisting("SingleInstanceApp");
				}
				catch (WaitHandleCannotBeOpenedException e)
				{
					//The mutex doesn't exist
					firstInstance = true;
				}
	
				//Create mutex if still null
				if (mutex == null)
				{
					mutex = new Mutex(false, "SingleInstanceApp");
					
					//Keep Garbage Collection away
					GC.KeepAlive(mutex);
				}
			}
            private bool firstInstance = false;
    
            //If returns true, the application already exists
            public bool FirstInstance
            {
                get { return firstInstance; }
            }
		}
