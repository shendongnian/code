    class Program
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("Kernel32")]
        private static extern IntPtr GetConsoleWindow();
        const int SW_HIDE = 0;
	    static void Main(string[] args)
        {
                // Let's hide the console window first ...
                IntPtr hwnd;
                hwnd = GetConsoleWindow();
                ShowWindow(hwnd, SW_HIDE);
                // I recommend you start a separate thread from here, I removed it for the sake of simplicity
                Boolean clientConnected = false;
                while (!clientConnected)
                {
	               try
	               {
 	                  LyncClient lyncClient = LyncClient.GetClient();
 	                  clientConnected = true;
			// Do your stuff here...
	               }
	               catch (ClientNotFoundException ex)
            	   {
                	  // Client not found : the client is probably not running...
                	  // There is nothing to do besides wait and expect to have the user starting his client...
                	  clientConnected = false; // not needed, just to highlight the fact that we are not connected yet
            	   }
            	// Don't forget to make your application sleep/do nothing on regular intervals to avoid taking 100% CPU time while you are polling
		       }
	}
