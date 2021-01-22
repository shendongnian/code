    // To integer
    int iCol = (color.A << 24) | (color.R << 16) | (color.G << 8) | color.B;
    
    // From integer
    Color color = Color.FromArgb((byte)(iCol >> 24), 
                                 (byte)(iCol >> 16), 
                                 (byte)(iCol >> 8), 
                                 (byte)(iCol));
