    public event EventHandler OnSomeEvent;
    
    protected void ErrorOccurInControl()
    {
         if (this.OnSomeEvent != null)
         {
              this.OnSomeEvent(this, new EventArgs());
         }
    }
    
    protected override void OnLoad(EventArgs e)
    {
         ErrorOccurInControl();
    }
