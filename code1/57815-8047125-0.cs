    private void AlternateButton_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = false;
        buttonHasBeenClicked = true;
        this.Close();
    }
    private void DefaultButton_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;
        buttonHasBeenClicked = true;
        this.Close();
    }
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        base.OnClosing(e);
        if (!buttonHasBeenClicked)
        {
            // Prevent the user closing the window without pressing one of the buttons.
            e.Cancel = true;
        }
    }
