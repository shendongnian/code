    Color text_color = Color.Black;
                if (text_color == new Color())
                { }
    
                if (text_color == Color.Transparent)
                { }
    
                if (text_color != Color.Black)
                { }
    
                if (text_color != Color.FromArgb(0, 255, 255, 255))
                { }
    
                if (text_color != Color.FromName("Red"))
                { }
    
                if (text_color == Color.FromKnownColor(KnownColor.Blue))
                { }
    
                if (text_color == ColorTranslator.FromHtml("#FFCC66"))
                { }
    
                if (text_color.R == 255
                    && text_color.G == 255
                    && text_color.B == 255
                    && text_color.A == 0)
                {
    
                }
