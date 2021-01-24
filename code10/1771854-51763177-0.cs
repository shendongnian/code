    private void ring() 
    {
        if (System.DateTime.Now.ToString("HH:mm") == temp && songisplaying == false) 
        {
            songisplaying = true;
            if (this.InvokeRequired) 
                this->Invoke(new MethodInvoker(()=>{ringOnMainThread()});
            else
                ringOnMainThread();
        }
    }
    private void ringOnMainThread()
    {
        soundplayer.PlayLooping();
        timer1.Start();
    
        if (WindowState == FormWindowState.Minimized)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }
 
        wakeupForm win = new wakeupForm();
        win.Show();
    }
