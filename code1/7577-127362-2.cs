    private void OpenAccessGates()
    {
       if (worker != null)
       {
          worker.CancelAsync();
          WaitForWorkerToFinish(worker);
       }
    
       if (!rocketOnPad)
       {
          DisengateAllGateLatches();
       }
    }
