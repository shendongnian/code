    public static Color FromName(string colorName)
    {
        System.Drawing.Color systemColor = System.Drawing.Color.FromName(colorName);   
        Color xnaColor = new Color(systemColor.R, systemColor.G, systemColor.B, systemColor.A); //Here Color is Microsoft.Xna.Framework.Graphics.Color
    }
