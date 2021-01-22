    public void ResetFields()
    {
        // use "delegate" instead of "() =>" if .Net version < 3.5
        InvokeOnFormThread(() => 
        {
            firstInput.Text = Defaults.FirstInput;
            secondInput.Text = Defaults.SecondInput;
            thirdChoice.SelectedIndex = Defaults.ThirdChoice;
        });
    }
    // change Action to MethodInvoker for .Net versions less than 3.5
    private void InvokeOnFormThread(Action behavior) 
    {
        if (IsHandleCreated && InvokeRequired)
        {
            Invoke(behavior);
        }
        else
        {
            behavior();
        }
    }
