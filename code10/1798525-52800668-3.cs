    private AsyncAutoResetEvent asyncAutoResetEvent = new AsyncAutoResetEvent();
    
    ...
    
    private async Task StartSimulation(object sender, EventArgs e)
    {
       while (execList.Count != 0)
       {
          Assign(MF, Mpre);
          retCT = ChooseTransition(execList);
          ttoexec = retCT[1];
          this.time = retCT[0];
          timer.Start();
          
          // stop here and leaves the UI responsive
          // until its set again
          await AsyncAutoResetEvent.WaitAsync();
    
          ExecuteTransition(ttoexec);
          execList.Remove(ttoexec);
       }
    }
    
    private void Timer_Tick(object sender,EventArgs e)
    {
        --time;
        ++k;
        output.Add("t.u : " + k + "  " + "M = [" + MF.GetRowVal() + "];");
        if (time == 0)
        {
            timer.Stop();
            AsyncAutoResetEvent.Set();
        }
    }
