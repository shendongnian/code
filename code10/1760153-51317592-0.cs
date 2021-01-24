    if (swVASN.IsRunning)
    {
         TimeSpan tsVASN = swVASN.Elapsed;
         double test = tsVASN.TotalSeconds;
         double test1;
         Double.TryParse(previousTimeVASN, out test1);
         txtVASN.Text = (test + test1).ToString(); 
    }
