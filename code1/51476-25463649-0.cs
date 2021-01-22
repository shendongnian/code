    public static Color LightenBy(this Color color, int percent)
    {
        return ChangeColorBrightness(color, percent/100.0);
    }
    
    public static Color DarkenBy(this Color color, int percent)
    {
        return ChangeColorBrightness(color, -1 * percent / 100.0); 
    }
