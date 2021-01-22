    object sync = new object();
    ManualResetEvent Wait = new ManualResetEvent();
    //you should create a place holder named MessageData for Message Data.
    List<MessageData> Messages = new List<MessageData>();
    internal void ShowMessage(string Test, string Title, ....)
    {
    	MessageData MSG = new MessageData(Test, Title);
    	Wait.Set();
    	lock(sync) Messages.Add(MSG);
    }
    // another thread should run here.
    void Private_Show()
    {
    	while(true)
	{
    		while(Messsages.Count != 0)
    		{
    			MessageData md;
    			lock(sync)
    			{
    				md = List[0];
    				List.RemoveAt(0);
    			}
    			MessageBox.Show(md.Text, md.Title, md....);
    		}
    		Wait.WaitOne();
    	}
    }
