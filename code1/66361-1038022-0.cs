    private Color ParseColor(string s, Color defaultColor)
    {
        try
        {
            ColorConverter cc = new ColorConverter();
            Color c = (Color)(cc.ConvertFromString(s));
            
            if (c != null)
            {
                return c;
            }
        }
        catch (Exception)
        {
        }
        return defaultColor;
    }
