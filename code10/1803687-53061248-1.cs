    public MainPage()
    {
        this.InitializeComponent();
        Window.Current.CoreWindow.PointerWheelChanged += CoreWindow_PointerWheelChanged;
    }
    private async void CoreWindow_PointerWheelChanged(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.PointerEventArgs args)
    {
        Debug.WriteLine(args.CurrentPoint.Properties.MouseWheelDelta);
        UIElement element;
        if (args.CurrentPoint.Properties.MouseWheelDelta > 0)
        {
            element = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Up);
            if (element == null)
            {
                element = FocusManager.FindLastFocusableElement(root) as UIElement;
            }
            var result = await FocusManager.TryFocusAsync(element, FocusState.Keyboard);
            Debug.WriteLine((element as Button).Content.ToString() + " focused: " + result.Succeeded);
        }
        else
        {
            element = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Down);
            if (element == null)
            {
                element = FocusManager.FindFirstFocusableElement(root) as UIElement;
            }
            var result = await FocusManager.TryFocusAsync(element, FocusState.Keyboard);
            Debug.WriteLine((element as Button).Content.ToString() + " focused: " + result.Succeeded);
        }
            
    }
