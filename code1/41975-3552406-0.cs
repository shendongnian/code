    public delegate void serviceGUIDelegate();
    private void updateGUI()
    {
    this.Invoke(new serviceGUIDelegate(serviceGUI));
    }
