    public int WindowHeight
    {
        get
        {
            return windowHeight;
        }
        set
        {
            if(windowHeight == value)
                return;
    
            windowHeight = value;
    
            UpdateWindowDisplay();
        }
    }
    private int windowHeight;
    
    public void UpdateWindowDisplay()
    {
        Window.UpdateHeight(WindowHeight);
        // Other window display logic
    }
