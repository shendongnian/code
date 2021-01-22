        #region message label click --------------------------------------------------------------------------
    private Timer messageLabelClickTimer = null;
    
    private void messageLabel_MouseUp(object sender, MouseButtonEventArgs e)
    {
      Debug.Print(e.ChangedButton.ToString() + " / Left:" + e.LeftButton.ToString() + "  Right:" + e.RightButton.ToString() + "  click: " + e.ClickCount.ToString());
      // (e.ClickCount == 2) don't work!!  Always 1 comes.
    
      if (e.ChangedButton == MouseButton.Left)
      {
        if (messageLabelClickTimer == null)
        {
          messageLabelClickTimer = new Timer();
          messageLabelClickTimer.Interval = 300;
          messageLabelClickTimer.Elapsed += new ElapsedEventHandler(messageLabelClickTimer_Tick);
        }
    
        if (! messageLabelClickTimer.Enabled)                                                 
        { // Equal: (e.ClickCount == 1)
          messageLabelClickTimer.Start();
        }
        else  
        { // Equal: (e.ClickCount == 2)
          messageLabelClickTimer.Stop();
    
          var player = new SoundPlayer(ExtraResource.bip_3short);               // Double clicked signal
          player.Play();
        }
      }
    }
    
    private void messageLabelClickTimer_Tick(object sender, EventArgs e)
    { // single-clicked
      messageLabelClickTimer.Stop();
    
      var player = new SoundPlayer(ExtraResource.bip_1short);                  // Single clicked signal
      player.Play();
    }    
    #endregion
