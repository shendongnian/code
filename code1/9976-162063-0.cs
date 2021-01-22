    ImageAttributes attribs = new ImageAttributes();
    List<ColorMap> colorMaps = new List<ColorMap>();
    //
    // Remap black top be transparent
    ColorMap remap = new ColorMap();
    remap.OldColor = Color.Black;
    remap.NewColor = Color.Transparent;
    colorMaps.Add(remap);
    //
    // ...add additional remapping entries here...
    //
    attribs.SetRemapTable(colorMaps.ToArray(), ColorAdjustType.Bitmap);
    context.Graphics.DrawImage(image, imageRect, 0, 0, 
                               imageRect.Width, imageRect.Height, 
                               GraphicsUnit.Pixel, attribs);
