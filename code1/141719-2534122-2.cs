    private object playSoundSync = new object();
    public void PlaySound(Sound someSound)
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
        {
          lock (this.playSoundSync)
          {
            PlaySound(someSound);
          }
        }));
    }
