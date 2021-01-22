    Thread dataThread;
    bool continueProcessing = true;
    String currentNetworkMember = "";
    
    public NotifyMemberRemoved(String member)
    {
       if (currentNetworkMember == member)
       {
             continueProcessing = false;
             // Incase the thread is blocked...
             dataThread.Interrupt();
       }
    }
    
    public void ProcessingLoop()
    {
        while (true)
        {
            currentNetworkMember = GetMemberToProcess();
            continueProcessing = true;
            while (continueProcessing)
            {
                try 
                {
                   // Process data...
                   ReadDataChunk();
                   ProcessDataChunk();
                }
                catch (InterruptedException e)
                {
                   // Whatever interrupted us must have set continueProcessing to false...
                }
            }
            UpdateGUI();
        }
    }
