    Color cNeedle = bmpNeedle.GetPixel(innerX, innerY);
    Color cHaystack = bmpHaystack.GetPixel(innerX + outerX, innerY + outerY);
    
    bool isDifferentRGB = cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B;
    bool isTransparent = cNeedle.A == 0;
    if (isDifferentRGB && !isTransparent)
    {
         goto notFound;
    }
