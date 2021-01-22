    private void RunMe()
    {
        if (!InvokeRequired)
        {
            myLabel.Text = "You pushed the button!";
        }
        else
        {
            Invoke(new ThreadStart(RunMe));
        }
    }
