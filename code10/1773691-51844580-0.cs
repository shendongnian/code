    bool ClientIsSignedIn = false;
    public void CheckSignedInState()
    {
        // some other code
        ClientIsSignedIn = client.IsSignedIn;
        lblVisualStatus.Invalidate();
    }
    private void lblVisualStatus_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.FillEllipse((ClientIsSignedIn) ? Brushes.Green : Brushes.Red, ((Control)sender).ClientRectangle);
    }
