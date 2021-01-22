    private void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        MyListener.StopListening();
        myTimer.Stop();
    }
