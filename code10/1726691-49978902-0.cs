    HttpWebRequest stocks = null;
    try
    {
       //your logic will be here.. 
        
           Dispatcher.BeginInvoke(new Action(() =>
           {
               txtName.Text = stockName;
             
           }), DispatcherPriority.Background);
    }
    catch (Exception e)
    {
       //throw e;
    }
