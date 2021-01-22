    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (  e.CloseReason == CloseReason.WindowsShutDown 
            ||e.CloseReason == CloseReason.ApplicationExitCall
            ||e.CloseReason == CloseReason.TaskManagerClosing) { 
           return; 
        }
        e.Cancel = true;
        //assuming you want the close-button to only hide the form, 
        //and are overriding the form's OnFormClosing method:
        this.Hide();
    }
