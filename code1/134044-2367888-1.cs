    private void DoGUISwitch()
    { 
        Invoke( ( MethodInvoker ) delegate {
            object1.Visible = true;
            object2.Visible = false;
        });
    } 
