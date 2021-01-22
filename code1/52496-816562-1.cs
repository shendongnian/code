    protected override void OnStartup(StartupEventArgs e)
    {
        EventManager.RegisterClassHandler(typeof(TextBox),
            TextBox.KeyUpEvent,
            new System.Windows.Input.KeyEventHandler(TextBox_KeyUp));
        base.OnStartup(e);
    }
    private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key != System.Windows.Input.Key.Enter) return;
        // your event handler here
        e.Handled = true;
        MessageBox.Show("Enter pressed");
    }
