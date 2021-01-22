    public void ProcessMyUserControl(Control control) {
        MyUserControl myControl = control as MyUserControl;
        if (myControl == null) 
        {
             // This was a different type of control, not your user control...
             return;
        }
        myControl.MyMethod();
    }
