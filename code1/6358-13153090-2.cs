    private static void Main()
    {
    	using (Mutex mutex = new Mutex(false, appGuid)) {
    		if (!mutex.WaitOne(0, false)) {
    			MessageBox.Show("Instance already running", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
    			return;
    		}
    
    		Application.Run(new Form1());
    	}
    }
