    public class ViewErrorCounterAction : TriggerAction<DependencyObject> {
    public ViewErrorCounterAction()
    {
        ViewErrorCounter = 0;  // initalize with 0 as there should not be such errors when the window is loaded
    }
    public int ViewErrorCounter
    {
        get
        {
            return System.Convert.ToInt32(GetValue(ViewErrorCounterProperty));
        }
        set
        {
            SetValue(ViewErrorCounterProperty, value);
        }
    }
    public static readonly DependencyProperty ViewErrorCounterProperty = DependencyProperty.Register("ViewErrorCounter", typeof(int), typeof(ViewErrorCounterAction), new PropertyMetadata(null));
    protected override void Invoke(object parameter)
    {
        var e = (ValidationErrorEventArgs)parameter;
        if ((e.Action == ValidationErrorEventAction.Added))
            ViewErrorCounter = ViewErrorCounter + 1;
        else if ((e.Action == ValidationErrorEventAction.Removed))
            ViewErrorCounter = ViewErrorCounter - 1;
    }
    }
