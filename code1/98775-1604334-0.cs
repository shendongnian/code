    if(progress < 100)
    {
      progress++;
      progessLabel.Text = String.Format("Loading...  Progress: {0}%", progress);
    }
    else
    {
      timer.Enabled = false;
    }
 
