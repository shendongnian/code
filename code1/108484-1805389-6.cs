    private void control_enter(object sender, EventArgs e)
    {
        thePreviousControl = theActiveControl;
        theActiveControl = sender as Control;
        Console.WriteLine("Active Control is now : " + theActiveControl.Name);
    }
