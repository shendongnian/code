    _Time = TimeSpan.FromSeconds(60);
     //Creating a new thread
     Thread newMessage = new Thread(runThread);     
    _Timer = new DispatcherTimer(new TimeSpan(0, 0, 1),DispatcherPriority.Normal, delegate
      {
        O2_Timer.Text = _Time.ToString("c");
        if (_Time == TimeSpan.FromSeconds(30))
        {
            //Starting the thread
            newMessage.Start();
        }
        if (_Time == TimeSpan.Zero)
        {
            _Timer.Stop();
            MessageBox.Show("timer done");
            Sub_Depth.Text = null;
        }
        _Time = _Time.Add(TimeSpan.FromSeconds(-1));
    }, Application.Current.Dispatcher);
    _Timer.Start();
    private static void runThread(){
        //The thread function
        MessageBox.Show("timer is at 30 seconds");
    }
