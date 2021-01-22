    private void OpenAccessGates()
    {
       if (worker != null)
       {
          worker.CancelAsync();
          WaitForWorkerToFinish(worker);
          worker = null;
       }
    
       if (!rocketOnPad)
       {
          DisengateAllGateLatches();
       }
    }
