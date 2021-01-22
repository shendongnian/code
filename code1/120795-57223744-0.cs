    /// <summary>
    /// Creates an image containing the given text.
    /// NOTE: the image should be disposed after use.
    /// </summary>
    /// <param name="text">Text to draw</param>
    /// <param name="fontOptional">Font to use, defaults to Control.DefaultFont</param>
    /// <param name="textColorOptional">Text color, defaults to Black</param>
    /// <param name="backColorOptional">Background color, defaults to white</param>
    /// <param name="minSizeOptional">Minimum image size, defaults the size required to display the text</param>
    /// <returns>The image containing the text, which should be disposed after use</returns>
    public static Image DrawTextImage(string text, Font fontOptional=null, Color? textColorOptional=null, Color? backColorOptional=null, Size? minSizeOptional=null)
    {
        Font font = Control.DefaultFont;
        if (fontOptional != null)
            font = (Font)fontOptional;
        Color textColor = Color.Black;
        if (textColorOptional != null)
            textColor = (Color)textColorOptional;
        Color backColor = Color.White;
        if (backColorOptional != null)
            backColor = (Color)backColorOptional;
        Size minSize = Size.Empty;
        if (minSizeOptional != null)
            minSize = (Size)minSizeOptional;
        //first, create a dummy bitmap just to get a graphics object
        SizeF textSize;
        using (Image img = new Bitmap(1, 1))
        {
            using (Graphics drawing = Graphics.FromImage(img))
            {
                //measure the string to see how big the image needs to be
                textSize = drawing.MeasureString(text, font);
                if (!minSize.IsEmpty)
                {
                    textSize.Width = textSize.Width > minSize.Width ? textSize.Width : minSize.Width;
                    textSize.Height = textSize.Height > minSize.Height ? textSize.Height : minSize.Height;
                }
            }
        }
        //create a new image of the right size
        Image retImg = new Bitmap((int)textSize.Width, (int)textSize.Height);
        using (var drawing = Graphics.FromImage(retImg))
        {
            //paint the background
            drawing.Clear(backColor);
            //create a brush for the text
            using (Brush textBrush = new SolidBrush(textColor))
            {
                drawing.DrawString(text, font, textBrush, 0, 0);
                drawing.Save();
            }
        }
        return retImg;
    }
