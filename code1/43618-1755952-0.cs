        /// <summary>
        /// Creates an icon for the specified style.
        /// </summary>
        /// <param name="style">The style.</param>
        /// <returns></returns>
        private static Bitmap CreateStyleIcon(Style style)
        {
            const int iconSize = 16; //the size of the icon
            System.Drawing.Rectangle iconArea = new System.Drawing.Rectangle(0, 0, iconSize, iconSize); //a rectangle area for the icon
            StyleSample ss = new StyleSample { Bounds = iconArea };
            if (style is CompositeStyle)
            {
                CompositeStyle compsiteStyle = style as CompositeStyle;
                if (compsiteStyle.AreaStyle != null) //do we have an area style?
                {
                    ss.ApplyAreaStyle(compsiteStyle.AreaStyle);
                }
                if (compsiteStyle.LineStyle != null) //do we have an LineStyle style?
                {
                    ss.ApplyLineStyle(compsiteStyle.LineStyle);
                }
                if (compsiteStyle.SymbolStyle != null) //do we have an SymbolStyle style?
                {
                    ss.ApplySymbol(compsiteStyle.SymbolStyle);
                }
            }
            if (style is AreaStyle)
            {
                ss.ApplyAreaStyle((AreaStyle)style);
            }
            if (style is BaseLineStyle)
            {
                ss.ApplyLineStyle((BaseLineStyle)style);
            }
            //draw the bitmap
            Bitmap iconBitmap = new Bitmap(iconSize, iconSize, System.Drawing.Imaging.PixelFormat.Format32bppArgb);//the bitmap to draw the icon to
            ss.DrawToBitmap(iconBitmap, iconArea);
            return iconBitmap;
        }
