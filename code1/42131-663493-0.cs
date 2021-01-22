    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        if (this.ClickMode != ClickMode.Hover)
        {
            e.Handled = true;
            // SNIP...
        }
        base.OnMouseLeftButtonDown(e);
    }
