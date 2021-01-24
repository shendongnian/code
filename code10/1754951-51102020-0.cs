    protected override void OnClosing(CancelEventArgs e)
    {
        if (UserConfirmsTheyWantToLoseChanges())
        {
            OnReturn(new ReturnEventArgs<MyWizardResult>(MyWizardResult.Canceled));
        }
        else
        {
            e.Cancel = true;
        }
    }
