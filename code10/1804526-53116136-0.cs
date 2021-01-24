    public MainPage()
    {
        this.InitializeComponent();
        CoreWindow.GetForCurrentThread().PointerWheelChanged += MainPage_PointerWheelChanged;
        this.Loaded += MainPage_Loaded;
    }
    
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {   // RootLayout is Grid name.
        childrenCount = RootLayout.Children.Count;
    }
    
    private int childrenCount; // sub items count 
    private int index; // index of focus control
    private bool IsFirt = true; // first use flag
    private void MainPage_PointerWheelChanged(CoreWindow sender, PointerEventArgs args)
    {
        //get mouse wheel delta
        var value = args.CurrentPoint.Properties.MouseWheelDelta;
    
        if (IsFirt)
        {
            switch (value)
            {
                case 120:
    
                    index = childrenCount;
                    if (index == 0)
                    {
                        index = childrenCount - 1;
                    }
                    else
                    {
                        index--;
                    }
                    break;
    
                case -120:
    
                    index = -1;
    
                    if (index == childrenCount - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                    break;
    
            }
    
            IsFirt = false;
        }
        else
        {
            switch (value)
            {
                case 120:
    
                    if (index == 0)
                    {
                        index = childrenCount - 1;
                    }
                    else
                    {
                        index--;
                    }
    
                    break;
    
                case -120:
    
                    if (index == childrenCount - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
    
                    break;
            }
    
        }
        // focus control with index
        var element = RootLayout.Children[index] as Control;
        element.Focus(FocusState.Keyboard);
    
    }
