    private object playSoundSync = new object();
    public void PlaySound()
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
        {
          lock (this.playSoundSync)
          {
            // play sound
          }
        }));
    }
