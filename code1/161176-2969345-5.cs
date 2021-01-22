    static Color[] _colors = new Color[] { Color.Black, Color.Red, Color.Blue, Color.White };
    static Color ConvertValToColor(int val)
    {
        if (val < 0 || val > _colors.Length)
            throw new ArgumentOutOfRangeException("val");
        return _colors[val];
    }
         
