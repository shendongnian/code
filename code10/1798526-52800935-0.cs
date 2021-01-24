     private void Timer_Tick(object sender,EventArgs e)
        {
            --time;
            ++k;
            
            if (time == 0)
            {
                ExecuteTransition(ttoexec);
                output.Add($"t.u : {k} M = [{MF.GetRowVal()}];");
                timer.Stop();
            }
            else
            {
                output.Add($"t.u : {k} M = [{MF.GetRowVal()}];");
            }
        }
        private bool isDone()
        {
            while (true)
            {
                if (!timer.Enabled) return true;
            }
        }
        private Task DoAsync()
        {
            return Task.Factory.StartNew(() => isDone());
        }
      private async void StartSimulation(object sender,EventArgs e)
      {  
        ...
        await DoAsync(); // it won't go further unless method isDone() return anything
        ...
       }
