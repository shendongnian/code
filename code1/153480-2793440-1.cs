    protected System.Drawing.Color GetForeColor(object statusObj)
    {
        System.Drawing.Color color = System.Drawing.Color.Black;
    
        switch ((string)statusObj)
        {
            case "A": color = System.Drawing.Color.Red; break;
            case "P": color = System.Drawing.Color.Green; break;
            case "L": color = System.Drawing.Color.Yellow; break;
        }
    
        return color;
    }
