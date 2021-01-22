    private UInt32Value createBorder(Stylesheet styleSheet,bool buttomBorderDouble)
            {
                Border border;
                //set borders of header
                if (buttomBorderDouble)
                {
               
      border = new Border
                    (
                    new BottomBorder { Style = BorderStyleValues.Double },
                    new DiagonalBorder());
            }
            else
            {
                 border = new Border
                    (
                    new BottomBorder {Style = BorderStyleValues.Thin},
                    new DiagonalBorder());
            }
            styleSheet.Borders.Append(border);
            UInt32Value result = styleSheet.Borders.Count;
            styleSheet.Borders.Count++;
            return result;
            
        }
        private UInt32Value createFont(Stylesheet styleSheet, string fontName, Nullable<double> fontSize, bool isBold, System.Drawing.Color foreColor, bool isUnderLine)
        {
            Font font = new Font();
            if (!string.IsNullOrEmpty(fontName))
            {
                FontName name = new FontName()
                {
                    Val = fontName
                };
                font.Append(name);
            }
            if (fontSize.HasValue)
            {
                FontSize size = new FontSize()
                {
                    Val = fontSize.Value
                };
                font.Append(size);
            }
            if (isBold == true)
            {
                Bold bold = new Bold();
                font.Append(bold);
            }
            if (isUnderLine == true)
            {
                Underline underline = new Underline();
                font.Append(underline);
            }
            if (foreColor != null)
            {
                Color color = new Color()
                {
                    Rgb = new HexBinaryValue()
                    {
                        Value =
                            System.Drawing.ColorTranslator.ToHtml(
                                System.Drawing.Color.FromArgb(
                                    foreColor.A,
                                    foreColor.R,
                                    foreColor.G,
                                    foreColor.B)).Replace("#", "")
                    }
                };
                font.Append(color);
            }
            styleSheet.Fonts.Append(font);
            UInt32Value result = styleSheet.Fonts.Count;
            styleSheet.Fonts.Count++;
            return result;
        }
    private UInt32Value createCellFormat(Stylesheet styleSheet, UInt32Value fontIndex, UInt32Value fillIndex, UInt32Value numberFormatId, UInt32Value borderId)
            {
                CellFormat cellFormat = new CellFormat();
    
                if (fontIndex != null)
                    cellFormat.FontId = fontIndex;
    
                if (fillIndex != null)
                    cellFormat.FillId = fillIndex;
    
                if (numberFormatId != null)
                {
                    cellFormat.NumberFormatId = numberFormatId;
                    cellFormat.ApplyNumberFormat = BooleanValue.FromBoolean(true);
                }
                if (borderId != null)
                    cellFormat.BorderId = borderId;
    
                styleSheet.CellFormats.Append(cellFormat);
    
                UInt32Value result = styleSheet.CellFormats.Count;
                styleSheet.CellFormats.Count++;
                return result;
            }
