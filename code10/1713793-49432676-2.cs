    public int ButtonSpacing = 10;
    public int ButtonWidth = 80;
    public int ButtonHeight = 30;
    
    public string[] Labels = { "Black", "Red", "Green", "Blue" };
    public Color[] Colors = { Color.black, Color.red, Color.green, Color.blue };
    
    private void OnGUI ()
    {
        var y = ButtonSpacing + ButtonHeight;
    
        for (var i = 0; i < 4; i++)
        {
            GUI.backgroundColor = Colors[i];
            GUI.Button(new Rect(ButtonSpacing, ButtonSpacing + i * y, ButtonWidth, ButtonHeight), Labels[i]);
        }
    }
