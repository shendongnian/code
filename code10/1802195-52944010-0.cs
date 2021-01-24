    private static readonly Dictionary<Type, Action<Control>> _Dispatcher = new Dictionary<Type, Action<Control>>
    {
        { typeof(MyControl), HandleMyFirstControl },
        { typeof(AnotherControl), HandleMySecondControl },
    };
    private static void HandleMyFirstControl(Control control)
    {
        var myControl = (MyControl)control;
        myControl.MySpecialValue = 73;
    }
    private static void HandleMySecondControl(Control control)
    {
        var anotherControl = (AnotherControl)control;
        anotherControl.Foo = Guid.NewGuid();
    }
    private void HandleControls()
    {
        foreach(var control in flowLayoutPanel.Controls)
        {
            if(_Dispatcher.TryGetValue(control.GetType(), out Action<Control> handler)
            {
                handler(control);
            }
        }
    }
