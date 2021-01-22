    // Borrowed from previous question
    using XnaColor = Microsoft.Xna.Framework.Graphics.Color;
    
    System.Drawing.Color clrColor = System.Drawing.Color.FromName("Red"); 
    XnaColor xnaColor = new XnaColor(clrColor.R, clrColor.G, clrColor.B, clrColor.A);
    // Working back the other way
    System.Drawing.Color newClrColor = System.Drawing.Color.FromArgb(xnaColor.A, xnaColor.R, xnaColor.G, xnaColor.B);
    System.Drawing.KnownColor kColor = newClrColor.ToKnownColor();
    string colorName = known != null ? known.ToString() : "";
