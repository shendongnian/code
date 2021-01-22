    //in startup code...
    timer = new System.Threading.Timer(CheckProcessAndKillIeIfNeedBe, null, 0L, (long)TimeSpan.FromMinutes(1).TotalMilliseconds);
    
    //some method elsewhere
    public void CheckProccessAndKillIeIfNeedBe(object state)
    {
      //do the process check and kill IE if conditions are met			
    }
