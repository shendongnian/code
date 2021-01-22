    private void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    	if (!e.Cancelled)
    	{
                rocketOnPad = false;
    		label1.Text = "Rocket launch complete";
    
    	}
    	else
    	{
                rocketOnPad  = true;
    		label1.Text = "Rocket launch aborted";
    	}
        worker = null;
    
        if (delayedBlowUpRocket)
           BlowUpRocket();
        else if (delayedOpenAccessGates)
           OpenAccessGates();
        else if (delayedDrainRocket)
           DrainRocket();
    }
    
    private void BlowUpRocket()
    {
       if (worker != null)
       {
          delayedBlowUpRocket = true;
          worker.CancelAsync();
          return;
       }
     
       Startclaxxon();
       SelfDestruct();
    }
    
    private void OpenAccessGates()
    {
       if (worker != null)
       {
          delayedOpenAccessGates = true;
          worker.CancelAsync();
          return;
       }
    
       if (!rocketOnPad)
       {
          DisengateAllGateLatches();
       }
    }
    
    private void DrainRocket()
    {
       if (worker != null)
       {
         delayedDrainRocket = true;
         worker.CancelAsync();
         return;
       }
    
       if (rocketOnPad)
          OpenFuelValves();
    }
