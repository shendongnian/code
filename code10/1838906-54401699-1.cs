    public void SetWindowHeight(int newHeight)
    {
        if(WindowHeight == newHeight)
            return;
    
        WindowHeight = newHeight;
    
        UpdateWindowDisplay();
    }
    public int GetWindowHeight()
    {
        return WindowHeight;
    }
    
    private int WindowHeight;
    
    
    public void UpdateWindowDisplay()
    {
        Window.UpdateHeight(WindowHeight);
        // Other window display logic
    }
