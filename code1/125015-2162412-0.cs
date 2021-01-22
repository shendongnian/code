    private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        TimeControl control = obj as TimeControl;
        var ts =  (TimeSpan)e.NewValue;
        if(ts.Hours != control.Hours) control.Hours = ts.Hours;
        if(ts.Minutes != control.Minutes) control.Minutes = ts.Minutes;
        if(ts.Seconds != control.Seconds) control.Seconds = ts.Seconds;
    }
