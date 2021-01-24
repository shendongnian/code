    protected override void OnMouseWheel(MouseEventArgs m)
    {
        if ((ModifierKeys & Keys.Control) != 0)
        {
            // Ignore CTRL+WHEEL
            return;
        }
    
        base.OnMouseWheel(m);
    }
