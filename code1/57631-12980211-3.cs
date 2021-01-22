    // Alternatively, you can attach an event listener to FrameworkElement.Loaded
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        // Be gentle here: If someone creates a (future) subclass or changes your control template,
        // you might not have tooltip anymore.
        ToolTip toolTip = this.ToolTip as ToolTip;
        if (null != toolTip)
        {
            // If I don't set this explicitly, placement is strange.
            toolTip.PlacementTarget = this;
            toolTip.Closed += new RoutedEventHandler(OnToolTipClosed);
        }
    }
    protected void OnToolTipClosed(object sender, RoutedEventArgs e)
    {
        // You may want to add additional focus-related tests here.
        if (this.IsKeyboardFocusWithin)
        {
            // We cannot set this.IsOpen directly here.  Instead, send an event asynchronously.
            // DispatcherPriority.Send is the highest priority possible.
            Dispatcher.CurrentDispatcher.BeginInvoke(
                (Action)delegate
                    {
                        // Again: Be gentle when using this.ToolTip.
                        ToolTip toolTip = this.ToolTip as ToolTip;
                        if (null != toolTip)
                        {
                            toolTip.IsOpen = true;
                        }
                    },
                DispatcherPriority.Send);
        }
    }
