    public SizeF CalculateWidth(Font font, Graphics graphics, int numOfLines,
                                string text)
    {
        SizeF sizeFull = graphics.MeasureString(text, font,
                                                new SizeF(
                                                    float.PositiveInfinity,
                                                    float.PositiveInfinity),
                                                StringFormat.
                                                    GenericTypographic);
    
        float width = sizeFull.Width/numOfLines;
        float averageWidth = sizeFull.Width/text.Length;
        int charsFitted;
        int linesFilled;
    
        SizeF needed = graphics.MeasureString(text, font,
                                              new SizeF(width,
                                                        float.
                                                            PositiveInfinity),
                                              StringFormat.
                                                  GenericTypographic,
                                              out charsFitted,
                                              out linesFilled);
    
        while (linesFilled > numOfLines)
        {
            width += averageWidth;
            needed = graphics.MeasureString(text, font,
                                            new SizeF(width,
                                                      float.PositiveInfinity),
                                            StringFormat.GenericTypographic,
                                            out charsFitted, out linesFilled);
        }
    
        return needed;
    }
