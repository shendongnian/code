    private void Button1_Click(object sender, EventArgs e)  
    {  
       var backgroundScheduler = TaskScheduler.Default;  
       var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();  
       Task.Factory.StartNew(delegate { DoBackgroundComputation(); },  
                             backgroundScheduler).  
       ContinueWith(delegate { UpdateUI(); }, uiScheduler).  
                    ContinueWith(delegate { DoAnotherBackgroundComputation(); },  
                                 backgroundScheduler).  
                    ContinueWith(delegate { UpdateUIAgain(); }, uiScheduler);  
    }  
