    using System.Threading;          // be sure to include the System.Threading namespace
        //Delegates for safe multi-threading.
        delegate void DelegateGetFocus();
        private DelegateGetFocus m_getFocus;
        //Constructor.
        myForm()
        {
	        m_getFocus = new DelegateGetFocus(this.getFocus);   // initialise getFocus
         	InitializeComponent();
        	spawnThread(keepFocus);                             // call spawnThread method
        }
        //Spawns a new Thread.
        private void spawnThread(ThreadStart ts)
        {
        	try
	        {
        		Thread newThread = new Thread(ts);
                newThread.IsBackground = true;
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
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(m_getFocus, new object[] { });
                }
                catch (System.ObjectDisposedException e)
                {
                    // Window was destroyed. No problem but terminate application.
                    Application.Exit();
                }
            }
            //Otherwise, we're safe.
            else
            {
                this.TopMost = true;
                this.Activate();
            }
        }		
	}
