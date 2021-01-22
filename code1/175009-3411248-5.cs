    var control = d as Control;
    if (control != null)
    {
        control.Dispatcher.BeginInvoke(new Action(() =>
        {
            control.ApplyTemplate();
            control.SetValue(ScrollViewerProperty,
                control.Template.FindName("PART_ContentHost", control)
                    as ScrollViewer);
        }));
    }
