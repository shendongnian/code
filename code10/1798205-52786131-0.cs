    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (progressBar1.InvokeRequired)
        {
            progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Value++; }));
        }
        else
        {
            progressBar1.Value++;
        }
        
    }
