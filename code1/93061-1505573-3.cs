    protected override void OnInit(System.EventArgs e)
    {               
         control1.ButtonEvent+= 
                  new Control1.ButtonEventHandler (whatever_ButtonEvent);
               
    }
    protected void whatever_ButtonEvent()
    {
        //do something
    }
