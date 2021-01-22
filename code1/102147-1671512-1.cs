    private void enableControlsMove()
    {
        foreach (Control theControl in panel1.Controls)
        {
            Console.WriteLine(theControl.Name);
            theControl.MouseDown += new MouseEventHandler(theControl_MouseDown);
            theControl.MouseUp += new MouseEventHandler(theControl_MouseUp);
            theControl.MouseMove += new MouseEventHandler(theControl_MouseMove);
        }
    }
    private void disableControlsMove()
    {
        foreach (Control theControl in panel1.Controls)
        {
            Console.WriteLine(theControl.Name);
            theControl.MouseDown -= theControl_MouseDown;
            theControl.MouseUp -= theControl_MouseUp;
            theControl.MouseMove -= theControl_MouseMove;
        }
    }
