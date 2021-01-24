   	    this.HostIpcToTray.CloseCallback();
      	this.IpcPipeFactory.Close();
     
       	private void IpcPipeFactory_Closing(object sender, EventArgs e)
    	{
    		this.IsConnectedPipeToTray = false;
    		this.HostIpcToTray = null;
    		this.IpcPipeFactory.Closing -= IpcPipeFactory_Closing;
        }
