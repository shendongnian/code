    protected override void OnKeyUp(KeyEventArgs e)
    {
        base.OnKeyUp(e);
        if (e.Key == Key.F10)
        {
            if (pickButton != null)
            {
                DoStuff();
            }
        }
    }
