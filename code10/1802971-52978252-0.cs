    private void UpdateOptions()
    {
         while (optionUpdates.syncUpdates.Count > 0)
         {
             try
             {
                 String optionNumber = null;
                 lock (_locker)
                 {
                     optionNumber = (String)optionUpdates.syncUpdates.Dequeue();
                     optionUpdates.hashes.Remove(optionNumber);                 
                     OutputNotification(GetTime(), "Option", optionNumber);
                 }          
             }
             catch (Exception ex)  { }
         }
    }
    
    public void OutputNotification(String _time, String _type, String _data)
    { 
        notifyShare.notifyTime = _time;
        notifyShare.notifyType = _type;
        notifyShare.notifyData = _data;  
        /* I'm not really sure if this call will be synchronously exected, but if 
         not  then the locking will not be useful and so I prefer to pass the notification 
         details as parameters to the method instead of using a shared object.*/
        this.Context.Post(new SendOrPostCallback(notificationUpdate), null);
    }
