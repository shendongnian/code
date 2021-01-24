    using (var path = new GraphicsPath())
    using (var format = new StringFormat(StringFormatFlags.NoClip | StringFormatFlags.NoWrap))
    {
        format.Alignment = [StringAlignment.Center/Near/Far]; //As selected
        format.LineAlignment = [StringAlignment.Center/Near/Far]; //As selected
        //Add the Text to the GraphicsPath
        path.AddString(fontObject.Text, fontObject.FontFamily, 
                       (int)fontObject.FontStyle, fontObject.SizeInEms, 
                       [Canvas].ClientRectangle, format);
        //Ems size (bounding rectangle)
        RectangleF TextBounds = path.GetBounds(null, fontObject.Outline);
        //Location of the Text
        fontObject.Location = TextBounds.Location;
    }
