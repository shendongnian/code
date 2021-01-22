    void SelectionEventHandler(object sender, EventArgs e)
    {
        var ownerElement = sender as FrameworkElement; // this should be the TreeView itself
        ThreadPool.QueueUserWorkItem(o => {
            
            // Do stuff 
       
            ownerElement.Dispatcher.BeginInvoke(new Action(() => {
    
                // Update UI in response to stuff being done
    
            });
        });
    }
