    public enum Color
    {
        Red,
        Blue,
        Green,
    }
    public string ConvertToHexWithIfElse(Color myColor)
    {
        if (myColor == Color.Red)
        {
            return "#FF0000";
        }
        else if (myColor == Color.Green)
        {
            return "#00FF00";
        }
        else if (myColor == Color.Blue)
        {
            return "#0000FF";
        }
        
        return string.Empty;
    }
    public string ConvertToHexWithSwitch(Color myColor)
    {
        switch (myColor)
        {
            case Color.Red:
                return "#FF0000";
            case Color.Blue:
                return "#0000FF";
            case Color.Green:
                return "#00FF00";
            default:
                return string.Empty;
        }
    }
