    //rotate hue for a pixel
    private Color CalculateHueChange(Color oldColor, float hue)
    {
        HLSRGB color = new HLSRGB(
            Convert.ToByte(oldColor.R),
            Convert.ToByte(oldColor.G),
            Convert.ToByte(oldColor.B));
    
        float startHue = color.Hue;
        color.Hue = startHue + hue;
        return color.Color;
    }
