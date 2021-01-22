    private void SetVisibility(Control target, bool visible)
    {
        if (target.InvokeRequired)
        {
            target.Invoke(new EventHandler(
                delegate
                {
                    target.Visible = visible;
                }));
        }
        else
        {
            target.Visible = visible;
        }
    }
