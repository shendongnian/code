     try 
     {
        control.Tag = true;
        // set the control property
        control.Value = xxx;
    or
        control.Index = xxx; 
    or
        control.Checked = xxx;
        ...
     }
     finally 
     {
        control.Tag = null;
     }
