    UILabel _placeholderLabel;
    protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
    {
      base.OnElementChanged(e);
      
      if (Control == null)
      {
        // Instantiate the native control and assign it to the Control property with
        // the SetNativeControl method
      }
      else
      {
        if (e.OldElement != null)
        {
          // Unsubscribe from event handlers and cleanup any resources
          Control.Started -= OnStarted;
        }
        if (e.NewElement != null)
        {
          // Configure the control and subscribe to event handlers
          _placeholderLabel = CreateLabel(); //not shown here
          Control.Started += OnStarted;
        }
      }
    ...
    void OnStarted(object sender, EventArgs e)
    {
      _placeholderLabel.Hidden = true;
    }
