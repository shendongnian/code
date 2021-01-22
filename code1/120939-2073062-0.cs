         protected override void OnStart(string [] args)
      {
    System.Threading.Thread workerThread =new System.Threading.Thread(longprocess());
    workerThread.start();
      }
    
    private void longprocess()
    {
    ///long stuff
    }
