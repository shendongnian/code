    private static Typeface NewTypeFaceFromFont(System.Drawing.Font f)
    {
        Typeface typeface = null;
        FontFamily ff = new FontFamily(f.Name);
        
        if (typeface == null)
        {
            typeface = new Typeface(ff, (f.Style == System.Drawing.FontStyle.Italic ? FontStyles.Italic : FontStyles.Normal),
                             (f.Style == System.Drawing.FontStyle.Bold ? FontWeights.Bold : FontWeights.Normal),
                                        FontStretches.Normal);
        }
        if (typeface == null)
        {
            typeface = new Typeface(new FontFamily("Arial"),
                                            FontStyles.Italic,
                                            FontWeights.Normal,
                                            FontStretches.Normal);            
        }
        return typeface;
        
    }
