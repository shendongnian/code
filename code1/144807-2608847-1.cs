    enum FormStates
    {
        Initial_View
        Working_View
        Edit_View
        Shutdown_View
    };
    
    { // Somewhere in code
    
    switch (theCurrentState)
    {
    
        case Initial_View :
            Control1.Enabled = true;
            Control2.Enabled = true;
            theCurrentState = Working_View;
        break;
    
       case Working_View
          if (string.empty(Contro1.Text) == false)
          {
              Control2.Enabled = false;
              Speachcontrol.Focus();
              theCurrentState = Edit_view;
          }
          else // Control 2 is operational
          {
             Control1.Enabled = false;
             SliderControl.Focus();
          }
    
        case Edit_View:
           ...
        break;  
    
       break;
    }
