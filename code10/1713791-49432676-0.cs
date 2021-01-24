    public int ButtonSpacing = 10;
    public int ButtonWidth = 80;
    public int ButtonHeight = 30;
    
    public string[] Labels = { "Black", "Red", "Green", "Blue" };
    public Color[] Colors = { Color.black, Color.red, Color.green, Color.blue };
    
    private void OnGUI ()
    {
        var height = ButtonSpacing + ButtonHeight;
    
        for (var i = 0; i < Labels.Length; i++)
        {
            GUI.backgroundColor = Colors[i];
            GUI.Button(new Rect(ButtonSpacing, ButtonSpacing + i * height, ButtonWidth, ButtonHeight), Labels[i]);
        }
    }
