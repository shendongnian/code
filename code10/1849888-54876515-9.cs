    private KeyboardStatusService KeyboardStatus { get; } = new KeyboardStatusService();
    private int _keyboardHeight;
    
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        KeyboardStatus.Subscribe(this);
        KeyboardStatus.KeyboardStatusChangeEvent += OnKeyboardStatusChanged;
        ...........
    }
    
    protected override void OnDestroy()
    {
        base.OnDestroy();
        KeyboardStatus.KeyboardStatusChangeEvent -= OnKeyboardStatusChanged;
        KeyboardStatus.Unsubscribe(this);
        ........
    }
    
    private void OnKeyboardStatusChanged(KeyboardStatusChangeEventArgs e)
    {
        var keyboardStatus = e.Status;
        if (keyboardStatus == KeyboardStatus.Open)
        {
            var heightDelta = e.VisibleHeightToDecorHeightDelta;
            // need to adjust keyboard height calculation based upon the prescribed adjustment for the Activity set as  WindowSoftInputMode
            // the presence of a toolbar and.or status bar
            _keyboardHeight = heightDelta - YourToolBarHeight - YourStatusBarHeight;
    
            // ADJUST THE HEIGHT OF YOUR VIEW HERE
    
        }
        else
        {
            // ADJUST THE HEIGHT OF YOUR VIEW HERE
        }
    }
