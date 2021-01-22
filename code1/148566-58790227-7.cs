    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close"))
            MessageBox.Show("Closed by calling Close()");
        else
            MessageBox.Show("Closed by X or Alt+F4");
    }
