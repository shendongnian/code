        //Delegates for safe multi-threading.
        delegate void DelegateGetFocus();
        private DelegateGetFocus m_getFocus;
        //Constructor.
        myForm()
        {
	        m_getFocus = new DelegateGetFocus(this.getFocus);   
         	InitializeComponent();
        	spawnThread(keepFocus);
        }
        //Spawns a new Thread.
        private void spawnThread(ThreadStart ts)
        {
        	try
	        {
        		Thread newThread = new Thread(ts);
        		newThread.Start();
        	}
	        catch(Exception e)
	        {
        		MessageBox.Show(e.Message, "Exception!", MessageBoxButtons.OK, 
			        MessageBoxIcon.Error);
	        }
        }
        //Continuously call getFocus.
        private void keepFocus()
        {
        	while(true)
        	{
        		getFocus();
			}
		}
	//Keeps Form on top and gives focus.
	private void getFocus()
	{
		//If we need to invoke this call from another thread.
		if(this.InvokeRequired)
		{
			this.Invoke(m_getFocus, new object[] { });
		}
		//Otherwise, we're safe.
		else
		{
			this.TopMost = true;
			this.Activate();
		}			
	}
